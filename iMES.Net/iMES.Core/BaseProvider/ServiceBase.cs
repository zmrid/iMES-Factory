using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using iMES.Core.CacheManager;
using iMES.Core.Configuration;
using iMES.Core.Const;
using iMES.Core.Enums;
using iMES.Core.Extensions;
using iMES.Core.Extensions.AutofacManager;
using iMES.Core.Filters;
using iMES.Core.ManageUser;
using iMES.Core.Services;
using iMES.Core.Tenancy;
using iMES.Core.Utilities;
using iMES.Core.WorkFlow;
using iMES.Entity;
using iMES.Entity.DomainModels;
using iMES.Entity.SystemModels;

namespace iMES.Core.BaseProvider
{
    public abstract class ServiceBase<T, TRepository> : ServiceFunFilter<T>
         where T : BaseEntity
         where TRepository : IRepository<T>
    {
        public ICacheService CacheContext
        {
            get
            {
                return AutofacContainerModule.GetService<ICacheService>();
            }
        }

        public Microsoft.AspNetCore.Http.HttpContext Context
        {
            get
            {
                return HttpContext.Current;
            }
        }
        private WebResponseContent Response { get; set; }

        protected IRepository<T> repository;

        private PropertyInfo[] _propertyInfo { get; set; } = null;
        private PropertyInfo[] TProperties
        {
            get
            {
                if (_propertyInfo != null)
                {
                    return _propertyInfo;
                }
                _propertyInfo = typeof(T).GetProperties();
                return _propertyInfo;
            }
        }

        public ServiceBase()
        {
        }

        public ServiceBase(TRepository repository)
        {
            Response = new WebResponseContent(true);
            this.repository = repository;
        }

        protected virtual void Init(IRepository<T> repository)
        {

        }

        protected virtual Type GetRealDetailType()
        {
            return typeof(T).GetCustomAttribute<EntityAttribute>()?.DetailTable?[0];
        }

        /// <summary>
        ///  2020.08.15???????????????????????????sql????????????(???????????????)
        /// </summary>
        /// <returns></returns>
        private IQueryable<T> GetSearchQueryable()
        {
            //2021.08.22??????????????????(????????????)????????????????????????
            //????????????sql??????????????????????????????
            if (QuerySql == null && !IsMultiTenancy)
            //  if ((QuerySql == null && !IsMultiTenancy) || UserContext.Current.IsSuperAdmin)
            {
                return repository.DbContext.Set<T>();
            }
            //??????sql,?????????????????????????????????????????????sql
            if (QuerySql != null && !IsMultiTenancy)
            // if ((QuerySql != null && !IsMultiTenancy) || UserContext.Current.IsSuperAdmin)
            {
                return repository.DbContext.Set<T>().FromSqlRaw(QuerySql);
            }
            string multiTenancyString = TenancyManager<T>.GetSearchQueryable(typeof(T).GetEntityTableName());
            return repository.DbContext.Set<T>().FromSqlRaw(multiTenancyString);
        }

        /// <summary>
        ///  2020.08.15?????????????????????????????????sql?????????????????????
        /// </summary>
        /// <returns></returns>
        private string GetMultiTenancySql(string ids, string tableKey)
        {
            return TenancyManager<T>.GetMultiTenancySql(typeof(T).GetEntityTableName(), ids, tableKey);
        }

        /// <summary>
        ///  2020.08.15???????????????????????????????????????
        /// </summary>
        private void CheckUpdateMultiTenancy(string ids, string tableKey)
        {
            string sql = GetMultiTenancySql(ids, tableKey);

            //?????????????????????
            //??????sql?????????(??????)?????????????????????:??????????????????????????????????????????
            //sql = $" {sql} and createid!={UserContext.Current.UserId}";
            object obj = repository.DapperContext.ExecuteScalar(sql, null);
            if (obj == null || obj.GetInt() == 0)
            {
                Response.Error("?????????????????????");
            }
        }


        /// <summary>
        ///  2020.08.15???????????????????????????????????????
        /// </summary>
        private void CheckDelMultiTenancy(string ids, string tableKey)
        {
            string sql = GetMultiTenancySql(ids, tableKey);

            //?????????????????????
            //??????sql?????????(??????)?????????????????????:?????????????????????????????????
            //sql = $" {sql} and createid!={UserContext.Current.UserId}";
            object obj = repository.DapperContext.ExecuteScalar(sql, null);
            int idsCount = ids.Split(",").Distinct().Count();
            if (obj == null || obj.GetInt() != idsCount)
            {
                Response.Error("?????????????????????");
            }
        }

        private const string _asc = "asc";
        /// <summary>
        /// ??????????????????
        /// </summary>
        /// <param name="pageData"></param>
        /// <param name="propertyInfo"></param>
        private Dictionary<string, QueryOrderBy> GetPageDataSort(PageDataOptions pageData, PropertyInfo[] propertyInfo)
        {
            if (base.OrderByExpression != null)
            {
                return base.OrderByExpression.GetExpressionToDic();
            }
            if (!string.IsNullOrEmpty(pageData.Sort))
            {
                if (pageData.Sort.Contains(","))
                {
                    var sortArr = pageData.Sort.Split(",").Where(x => propertyInfo.Any(c => c.Name == x)).Select(s => s).Distinct().ToList();
                    Dictionary<string, QueryOrderBy> sortDic = new Dictionary<string, QueryOrderBy>();
                    foreach (var name in sortArr)
                    {
                        sortDic[name] = pageData.Order?.ToLower() == _asc ? QueryOrderBy.Asc : QueryOrderBy.Desc;
                    }
                    return sortDic;
                }
                else if (propertyInfo.Any(x => x.Name == pageData.Sort))
                {
                    return new Dictionary<string, QueryOrderBy>() { {
                            pageData.Sort,
                            pageData.Order?.ToLower() == _asc? QueryOrderBy.Asc: QueryOrderBy.Desc
                     } };
                }
            }
            //????????????????????????????????????????????????????????????

            PropertyInfo property = propertyInfo.GetKeyProperty();
            //???????????????????????????????????????appsettings.json???CreateMember->DateField?????????????????????????????????
            if (property.PropertyType == typeof(int) || property.PropertyType == typeof(long))
            {
                if (!propertyInfo.Any(x => x.Name.ToLower() == pageData.Sort))
                {
                    pageData.Sort = propertyInfo.GetKeyName();
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(AppSetting.CreateMember.DateField)
                    && propertyInfo.Any(x => x.Name == AppSetting.CreateMember.DateField))
                {
                    pageData.Sort = AppSetting.CreateMember.DateField;
                }
                else
                {
                    pageData.Sort = propertyInfo.GetKeyName();
                }
            }
            return new Dictionary<string, QueryOrderBy>() { {
                    pageData.Sort, pageData.Order?.ToLower() == _asc? QueryOrderBy.Asc: QueryOrderBy.Desc
                } };
        }


        /// <summary>
        /// ????????????????????????????????????
        /// </summary>
        /// <param name="options"></param>
        /// <param name="queryable"></param>
        /// <returns></returns>
        private PageDataOptions ValidatePageOptions(PageDataOptions options, out IQueryable<T> queryable)
        {
            options = options ?? new PageDataOptions();

            List<SearchParameters> searchParametersList = new List<SearchParameters>();
            if (!string.IsNullOrEmpty(options.Wheres))
            {
                try
                {
                    searchParametersList = options.Wheres.DeserializeObject<List<SearchParameters>>();
                }
                catch { }
            }
            QueryRelativeList?.Invoke(searchParametersList);
            //  Connection
            // queryable = repository.DbContext.Set<T>();
            //2020.08.15???????????????????????????sql????????????
            queryable = GetSearchQueryable();

            //??????????????????????????????????????????????????????????????????????????????
            for (int i = 0; i < searchParametersList.Count; i++)
            {
                SearchParameters x = searchParametersList[i];
                x.DisplayType = x.DisplayType.GetDBCondition();
                if (string.IsNullOrEmpty(x.Value))
                {
                    continue;
                }
                PropertyInfo property = TProperties.Where(c => c.Name.ToUpper() == x.Name.ToUpper()).FirstOrDefault();
                //2020.06.25????????????null??????
                if (property == null) continue;
                // property
                //??????????????????????????????????????????????????????
                object[] values = property.ValidationValueForDbType(x.Value.Split(',')).Where(q => q.Item1).Select(s => s.Item3).ToArray();
                if (values == null || values.Length == 0)
                {
                    continue;
                }
                if (x.DisplayType == HtmlElementType.Contains)
                    x.Value = string.Join(",", values);
                LinqExpressionType expressionType = x.DisplayType.GetLinqCondition();
                queryable = LinqExpressionType.In == expressionType
                              ? queryable.Where(x.Name.CreateExpression<T>(values, expressionType))
                              : queryable.Where(x.Name.CreateExpression<T>(x.Value, expressionType));
            }
            options.TableName = base.TableName ?? typeof(T).Name;
            return options;
        }

        /// <summary>
        /// ??????????????????
        /// </summary>
        /// <param name="loadSingleParameters"></param>
        /// <returns></returns>
        public virtual PageGridData<T> GetPageData(PageDataOptions options)
        {
            options = ValidatePageOptions(options, out IQueryable<T> queryable);
            //??????????????????
            Dictionary<string, QueryOrderBy> orderbyDic = GetPageDataSort(options, TProperties);

            PageGridData<T> pageGridData = new PageGridData<T>();
            if (QueryRelativeExpression != null)
            {
                queryable = QueryRelativeExpression.Invoke(queryable);
            }
            if (options.Export)
            {
                pageGridData.rows = queryable.GetIQueryableOrderBy(orderbyDic).Take(Limit).ToList();
            }
            else
            {
                pageGridData.rows = repository.IQueryablePage(queryable,
                                    options.Page,
                                    options.Rows,
                                    out int rowCount,
                                    orderbyDic).ToList();
                pageGridData.total = rowCount;
                //??????????????????????????????
                if (SummaryExpress != null)
                {
                    pageGridData.summary = SummaryExpress.Invoke(queryable);
                    //Func<T, T> groupExpress = x =>x;
                    //pageGridData.summary = queryable.GroupBy(groupExpress).Select(SummaryExpress).FirstOrDefault();
                }
            }
            GetPageDataOnExecuted?.Invoke(pageGridData);
            return pageGridData;

        }

        public virtual object GetDetailPage(PageDataOptions pageData)
        {
            Type detailType = typeof(T).GetCustomAttribute<EntityAttribute>()?.DetailTable?[0];
            if (detailType == null)
            {
                return null;
            }
            object obj = typeof(ServiceBase<T, TRepository>)
                 .GetMethod("GetDetailPage", BindingFlags.Instance | BindingFlags.NonPublic)
                 .MakeGenericMethod(new Type[] { detailType }).Invoke(this, new object[] { pageData });
            return obj;
        }
        protected override object GetDetailSummary<Detail>(IQueryable<Detail> queryeable)
        {
            return null;
        }

        private PageGridData<Detail> GetDetailPage<Detail>(PageDataOptions options) where Detail : class
        {
            //?????????????????????????????????????????????????????????
            PageGridData<Detail> gridData = new PageGridData<Detail>();
            if (options.Value == null) return gridData;
            //??????????????????
            string keyName = typeof(T).GetKeyName();

            //??????????????????
            Expression<Func<Detail, bool>> whereExpression = keyName.CreateExpression<Detail>(options.Value, LinqExpressionType.Equal);

            var queryeable = repository.DbContext.Set<Detail>().Where(whereExpression);

            gridData.total = queryeable.Count();
            options.Sort = options.Sort ?? typeof(Detail).GetKeyName();
            Dictionary<string, QueryOrderBy> orderBy = GetPageDataSort(options, typeof(Detail).GetProperties());

            gridData.rows = queryeable
                 .GetIQueryableOrderBy(orderBy)
                .Skip((options.Page - 1) * options.Rows)
                .Take(options.Rows)
                .ToList();
            gridData.summary = GetDetailSummary<Detail>(queryeable);
            return gridData;
        }



        /// <summary>
        /// ????????????
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public virtual WebResponseContent Upload(List<Microsoft.AspNetCore.Http.IFormFile> files)
        {
            if (files == null || files.Count == 0) return Response.Error("???????????????");

            //var limitFiles = files.Where(x => x.Length > LimitUpFileSizee * 1024 * 1024).Select(s => s.FileName);
            //if (limitFiles.Count() > 0)
            //{
            //    return Response.Error($"???????????????????????????{ LimitUpFileSizee}M,{string.Join(",", limitFiles)}");
            //}
            string filePath = $"Upload/Tables/{typeof(T).GetEntityTableName()}/{DateTime.Now.ToString("yyyMMddHHmmsss") + new Random().Next(1000, 9999)}/";
            string fullPath = filePath.MapPath(true);
            int i = 0;
            //   List<string> fileNames = new List<string>();
            try
            {
                if (!Directory.Exists(fullPath)) Directory.CreateDirectory(fullPath);
                for (i = 0; i < files.Count; i++)
                {
                    string fileName = files[i].FileName;
                    //if (fileNames.Contains(fileName))
                    //{
                    //    fileName += $"({i}){fileName}";
                    //}
                    //fileNames.Add(fileName);
                    using (var stream = new FileStream(fullPath + fileName, FileMode.Create))
                    {
                        files[i].CopyTo(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"?????????????????????{typeof(T).GetEntityTableCnName()},?????????{filePath},????????????:{files[i]},{ex.Message + ex.StackTrace}");
                return Response.Error("??????????????????");
            }
            return Response.OK("??????????????????", filePath);
        }

        private List<string> GetIgnoreTemplate()
        {
            //?????????????????????????????????????????????
            List<string> ignoreTemplate = UserIgnoreFields.ToList();
            ignoreTemplate.AddRange(auditFields.ToList());
            return ignoreTemplate;
        }

        public virtual WebResponseContent DownLoadTemplate()
        {
            string tableName = typeof(T).GetEntityTableCnName();

            string dicPath = $"Download/{DateTime.Now.ToString("yyyMMdd")}/Template/".MapPath();
            if (!Directory.Exists(dicPath)) Directory.CreateDirectory(dicPath);
            string fileName = tableName + DateTime.Now.ToString("yyyyMMddHHssmm") + ".xlsx";
            //DownLoadTemplateColumns 2020.05.07????????????????????????????????????
            EPPlusHelper.ExportTemplate<T>(DownLoadTemplateColumns, GetIgnoreTemplate(), dicPath, fileName);
            return Response.OK(null, dicPath + fileName);
        }

        /// <summary>
        /// ???????????????Excel?????????
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public virtual WebResponseContent Import(List<Microsoft.AspNetCore.Http.IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return new WebResponseContent { Status = true, Message = "????????????????????????" };
            Microsoft.AspNetCore.Http.IFormFile formFile = files[0];
            string dicPath = $"Upload/{DateTime.Now.ToString("yyyMMdd")}/{typeof(T).Name}/".MapPath();
            if (!Directory.Exists(dicPath)) Directory.CreateDirectory(dicPath);
            dicPath = $"{dicPath}{Guid.NewGuid().ToString()}_{formFile.FileName}";

            using (var stream = new FileStream(dicPath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            try
            {
                //2022.06.20????????????excel????????????(??????????????????????????????excel??????)
                Response = EPPlusHelper.ReadToDataTable<T>(dicPath, DownLoadTemplateColumns, GetIgnoreTemplate(), readValue: ImportOnReadCellValue);
            }
            catch (Exception ex)
            {
                Response.Error("???????????????????????????,????????????????????????????????????");
                Logger.Error($"???{typeof(T).GetEntityTableCnName()}????????????{ex.Message + ex.InnerException?.Message}");
            }
            if (CheckResponseResult()) return Response;
            List<T> list = Response.Data as List<T>;
            if (ImportOnExecuting != null)
            {
                Response = ImportOnExecuting.Invoke(list);
                if (CheckResponseResult()) return Response;
            }
            //2022.01.08???????????????????????????
            if (HttpContext.Current.Request.Query.ContainsKey("table"))
            {
                ImportOnExecuted?.Invoke(list);
                return Response.OK("??????????????????", list.Serialize());
            }
            repository.AddRange(list, true);
            if (ImportOnExecuted != null)
            {
                Response = ImportOnExecuted.Invoke(list);
                if (CheckResponseResult()) return Response;
            }
            return Response.OK("??????????????????");
        }

        /// <summary>
        /// ??????
        /// </summary>
        /// <param name="pageData"></param>
        /// <returns></returns>
        public virtual WebResponseContent Export(PageDataOptions pageData)
        {
            pageData.Export = true;
            List<T> list = GetPageData(pageData).rows;
            string tableName = typeof(T).GetEntityTableCnName();
            string fileName = tableName + DateTime.Now.ToString("yyyyMMddHHssmm") + ".xlsx";
            string folder = DateTime.Now.ToString("yyyyMMdd");
            string savePath = $"Download/ExcelExport/{folder}/".MapPath();
            List<string> ignoreColumn = new List<string>();
            if (ExportOnExecuting != null)
            {
                Response = ExportOnExecuting(list, ignoreColumn);
                if (CheckResponseResult()) return Response;
            }
            //ExportColumns 2020.05.07????????????????????????????????????
            EPPlusHelper.Export(list, ExportColumns?.GetExpressionToArray(), ignoreColumn, savePath, fileName);
            //return Response.OK(null, (savePath + "/" + fileName).EncryptDES(AppSetting.Secret.ExportFile));
            //2022.01.08??????????????????
            return Response.OK(null, (savePath + "/" + fileName));
        }

        /// <summary>
        /// ??????
        /// </summary>
        /// <param name="saveDataModel"></param>
        /// <returns></returns>
        public virtual WebResponseContent Add(SaveModel saveDataModel)
        {
            if (AddOnExecute != null)
            {
                Response = AddOnExecute(saveDataModel);
                if (CheckResponseResult()) return Response;
            }
            if (saveDataModel == null
                || saveDataModel.MainData == null
                || saveDataModel.MainData.Count == 0)
                return Response.Set(ResponseType.ParametersLack, false);

            saveDataModel.DetailData = saveDataModel.DetailData?.Where(x => x.Count > 0).ToList();
            Type type = typeof(T);

            string validReslut = type.ValidateDicInEntity(saveDataModel.MainData, true, UserIgnoreFields);

            if (!string.IsNullOrEmpty(validReslut)) return Response.Error(validReslut);

            if (saveDataModel.MainData.Count == 0)
                return Response.Error("?????????????????????????????????model??????????????????!");

            UserInfo userInfo = UserContext.Current.UserInfo;
            saveDataModel.SetDefaultVal(AppSetting.CreateMember, userInfo);

            PropertyInfo keyPro = type.GetKeyProperty();
            if (keyPro.PropertyType == typeof(Guid))
            {
                saveDataModel.MainData.Add(keyPro.Name, Guid.NewGuid());
            }
            else
            {
                saveDataModel.MainData.Remove(keyPro.Name);
            }
            //??????????????????????????????
            if (saveDataModel.DetailData == null || saveDataModel.DetailData.Count == 0)
            {
                T mainEntity = saveDataModel.MainData.DicToEntity<T>();
                SetAuditDefaultValue(mainEntity);
                if (base.AddOnExecuting != null)
                {
                    Response = base.AddOnExecuting(mainEntity, null);
                    if (CheckResponseResult()) return Response;
                }
                Response = repository.DbContextBeginTransaction(() =>
                {
                    repository.Add(mainEntity, true);
                    saveDataModel.MainData[keyPro.Name] = keyPro.GetValue(mainEntity);
                    Response.OK(ResponseType.SaveSuccess);
                    if (base.AddOnExecuted != null)
                    {
                        Response = base.AddOnExecuted(mainEntity, null);
                    }
                    return Response;
                });
                if (Response.Status) Response.Data = new { data = saveDataModel.MainData };
                AddProcese(mainEntity);
                return Response;
            }

            Type detailType = GetRealDetailType();

            return typeof(ServiceBase<T, TRepository>)
                .GetMethod("Add", BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(new Type[] { detailType })
                .Invoke(this, new object[] { saveDataModel })
                as WebResponseContent;
        }

        public virtual WebResponseContent AddEntity(T entity, bool validationEntity = true)
        {
            return Add<T>(entity, null, validationEntity);
        }

        /// <summary>
        /// ????????????????????????
        /// </summary>
        /// <typeparam name="TDetail"></typeparam>
        /// <param name="entity"></param>
        /// <param name="list"></param>
        /// <param name="validationEntity">????????????????????????</param>
        /// <returns></returns>
        public WebResponseContent Add<TDetail>(T entity, List<TDetail> list = null, bool validationEntity = true) where TDetail : class
        {
            //?????????????????????
            entity.SetCreateDefaultVal();
            SetAuditDefaultValue(entity);
            if (validationEntity)
            {
                Response = entity.ValidationEntity();
                if (CheckResponseResult()) return Response;
                if (list != null && list.Count > 0)
                {
                    Response = list.ValidationEntity();
                    if (CheckResponseResult()) return Response;
                }
            }
            if (this.AddOnExecuting != null)
            {
                Response = AddOnExecuting(entity, list);
                if (CheckResponseResult()) return Response;
            }
            Response = repository.DbContextBeginTransaction(() =>
            {
                repository.Add(entity);
                repository.DbContext.SaveChanges();
                //????????????
                if (list != null && list.Count > 0)
                {
                    //???????????????????????????
                    PropertyInfo mainKey = typeof(T).GetKeyProperty();
                    PropertyInfo detailMainKey = typeof(TDetail).GetProperties()
                        .Where(q => q.Name.ToLower() == mainKey.Name.ToLower()).FirstOrDefault();
                    object keyValue = mainKey.GetValue(entity);
                    list.ForEach(x =>
                    {
                        //?????????????????????
                        x.SetCreateDefaultVal();
                        detailMainKey.SetValue(x, keyValue);
                        repository.DbContext.Entry<TDetail>(x).State = EntityState.Added;
                    });
                    repository.DbContext.SaveChanges();
                }
                Response.OK(ResponseType.SaveSuccess);
                if (AddOnExecuted != null)
                    Response = AddOnExecuted(entity, list);
                return Response;
            });
            if (Response.Status && string.IsNullOrEmpty(Response.Message))
            {
                Response.OK(ResponseType.SaveSuccess);
            }
            AddProcese(entity);
            return Response;
        }

        /// <summary>
        /// ???????????????????????????
        /// </summary>
        /// <param name="entity"></param>
        private void SetAuditDefaultValue(T entity)
        {
            if (!WorkFlowManager.Exists<T>())
            {
                return;
            }
            var propertity = TProperties.Where(x => x.Name.ToLower() == "auditstatus").FirstOrDefault();
            if (propertity != null && propertity.GetValue(entity) == null)
            {
                propertity.SetValue(entity, 0);
            }
        }
        /// <summary>
        /// ????????????
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="changeTableStatus">?????????????????????????????????</param>
        protected void RewriteFlow(T entity,bool changeTableStatus = true) 
        {
            WorkFlowManager.AddProcese(entity, true, changeTableStatus);
        }
        private void AddProcese(T entity)
        {
            if (!CheckResponseResult() && WorkFlowManager.Exists<T>())
            {
                if (AddWorkFlowExecuting != null && !AddWorkFlowExecuting.Invoke(entity))
                {
                    return;
                }
                //????????????
                WorkFlowManager.AddProcese<T>(entity);
                WorkFlowManager.Audit<T>(entity, AuditStatus.?????????, null, null, null, null, init: true, initInvoke: AddWorkFlowExecuted);
            }
        }

        public void AddDetailToDBSet<TDetail>() where TDetail : class
        {
            List<PropertyInfo> listChilds = TProperties.Where(x => x.PropertyType.Name == "List`1").ToList();
            // repository.DbContext.Set<TDetail>().AddRange();
        }

        private WebResponseContent Add<TDetail>(SaveModel saveDataModel) where TDetail : class
        {
            T mainEntity = saveDataModel.MainData.DicToEntity<T>();
            //????????????
            string reslut = typeof(TDetail).ValidateDicInEntity(saveDataModel.DetailData, true, false, new string[] { TProperties.GetKeyName() });
            if (reslut != string.Empty)
                return Response.Error(reslut);

            List<TDetail> list = saveDataModel.DetailData.DicToList<TDetail>();
            Response = Add<TDetail>(mainEntity, list, false);

            //????????????
            if (CheckResponseResult())
            {
                Logger.Error(LoggerType.Add, saveDataModel.Serialize() + Response.Message);
                return Response;
            }

            PropertyInfo propertyKey = typeof(T).GetKeyProperty();
            saveDataModel.MainData[propertyKey.Name] = propertyKey.GetValue(mainEntity);
            Response.Data = new { data = saveDataModel.MainData, list };
            return Response.Set(ResponseType.SaveSuccess);
        }

        #region ??????

        /// <summary>
        /// ????????????????????????
        /// </summary>
        /// <typeparam name="DetailT"></typeparam>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="detailKeyName"></param>
        /// <param name="mainKeyName"></param>
        /// <param name="mainKeyValue"></param>
        /// <returns></returns>
        public List<Tkey> GetUpdateDetailSelectKeys<DetailT, Tkey>(string detailKeyName, string mainKeyName, string mainKeyValue) where DetailT : class
        {
            IQueryable<DetailT> queryable = repository.DbContext.Set<DetailT>();
            Expression<Func<DetailT, Tkey>> selectExpression = detailKeyName.GetExpression<DetailT, Tkey>();
            Expression<Func<DetailT, bool>> whereExpression = mainKeyName.CreateExpression<DetailT>(mainKeyValue, LinqExpressionType.Equal);
            List<Tkey> detailKeys = queryable.Where(whereExpression).Select(selectExpression).ToList();
            return detailKeys;
        }

        /// <summary>
        /// ???????????????????????????????????????
        /// </summary>
        /// <typeparam name="DetailT"></typeparam>
        /// <param name="saveModel"></param>
        /// <param name="mainKeyProperty"></param>
        /// <param name="detailKeyInfo"></param>
        /// <param name="keyDefaultVal"></param>
        /// <returns></returns>
        public WebResponseContent UpdateToEntity<DetailT>(SaveModel saveModel, PropertyInfo mainKeyProperty, PropertyInfo detailKeyInfo, object keyDefaultVal) where DetailT : class
        {
            T mainEnity = saveModel.MainData.DicToEntity<T>();
            List<DetailT> detailList = saveModel.DetailData.DicToList<DetailT>();
            //2021.08.21?????????????????????
            //???????????????
            //??????????????????????????????ID
            //System.Collections.IList detailKeys = this.GetType().GetMethod("GetUpdateDetailSelectKeys")
            //        .MakeGenericMethod(new Type[] { typeof(DetailT), detailKeyInfo.PropertyType })
            //        .Invoke(this, new object[] {
            //            detailKeyInfo.Name, mainKeyProperty.Name,
            //            saveModel.MainData[mainKeyProperty.Name].ToString()
            //        }) as System.Collections.IList;

            //????????????
            List<DetailT> addList = new List<DetailT>();
            //   List<object> containsKeys = new List<object>();
            //????????????
            List<DetailT> editList = new List<DetailT>();
            //???????????????
            List<object> delKeys = new List<object>();
            mainKeyProperty = typeof(DetailT).GetProperties().Where(x => x.Name == mainKeyProperty.Name).FirstOrDefault();
            //??????????????????????????????
            foreach (DetailT item in detailList)
            {
                object value = detailKeyInfo.GetValue(item);
                if (keyDefaultVal.Equals(value))//?????????????????????,????????????
                {
                    //???????????????????????????
                    mainKeyProperty.SetValue(item,
                        saveModel.MainData[mainKeyProperty.Name]
                        .ChangeType(mainKeyProperty.PropertyType));

                    if (detailKeyInfo.PropertyType == typeof(Guid))
                    {
                        detailKeyInfo.SetValue(item, Guid.NewGuid());
                    }
                    addList.Add(item);
                }
                else //if (detailKeys.Contains(value))
                {
                    //containsKeys.Add(value);
                    editList.Add(item);
                }
            }

            //????????????????????????????????????
            if (saveModel.DelKeys != null && saveModel.DelKeys.Count > 0)
            {
                //2021.08.21?????????????????????
                delKeys = saveModel.DelKeys.Select(q => q.ChangeType(detailKeyInfo.PropertyType)).Where(x => x != null).ToList();
                //.Where(x => detailKeys.Contains(x.ChangeType(detailKeyInfo.PropertyType)))
                //.Select(q => q.ChangeType(detailKeyInfo.PropertyType)).ToList();
            }

            if (UpdateOnExecuting != null)
            {
                Response = UpdateOnExecuting(mainEnity, addList, editList, delKeys);
                if (CheckResponseResult())
                    return Response;
            }
            mainEnity.SetModifyDefaultVal();
            //????????????
            //?????????!CreateFields.Contains???????????????
            repository.Update(mainEnity, typeof(T).GetEditField()
                .Where(c => saveModel.MainData.Keys.Contains(c) && !CreateFields.Contains(c))
                .ToArray());
            //foreach (var item in saveModel.DetailData)
            //{
            //    item.SetModifyDefaultVal();
            //}
            //????????????
            editList.ForEach(x =>
            {
                //?????????????????????
                var updateField = saveModel.DetailData
                    .Where(c => c[detailKeyInfo.Name].ChangeType(detailKeyInfo.PropertyType)
                    .Equal(detailKeyInfo.GetValue(x)))
                    .FirstOrDefault()
                    .Keys.Where(k => k != detailKeyInfo.Name)
                    .Where(r => !CreateFields.Contains(r))
                    .ToList();
                updateField.AddRange(ModifyFields);
                //???????????????
                x.SetModifyDefaultVal();
                //??????????????????
                repository.Update<DetailT>(x, updateField.ToArray());
            });

            //????????????
            addList.ForEach(x =>
            {
                x.SetCreateDefaultVal();
                repository.DbContext.Entry<DetailT>(x).State = EntityState.Added;
            });
            //????????????
            delKeys.ForEach(x =>
            {
                DetailT delT = Activator.CreateInstance<DetailT>();
                detailKeyInfo.SetValue(delT, x);
                repository.DbContext.Entry<DetailT>(delT).State = EntityState.Deleted;
            });

            if (UpdateOnExecuted == null)
            {
                repository.DbContext.SaveChanges();
                Response.OK(ResponseType.SaveSuccess);
            }
            else
            {
                Response = repository.DbContextBeginTransaction(() =>
                {
                    repository.DbContext.SaveChanges();
                    Response = UpdateOnExecuted(mainEnity, addList, editList, delKeys);
                    return Response;
                });
            }
            if (Response.Status)
            {
                addList.AddRange(editList);
                Response.Data = new { data = mainEnity, list = addList };
                if (string.IsNullOrEmpty(Response.Message))
                    Response.OK(ResponseType.SaveSuccess);
            }
            return Response;
        }

        /// <summary>
        /// ????????????????????????ID?????????????????????,?????????ID????????????????????????????????????????????????
        /// </summary>
        private static string[] _userIgnoreFields { get; set; }

        private static string[] UserIgnoreFields
        {
            get
            {
                if (_userIgnoreFields != null) return _userIgnoreFields;
                List<string> fields = new List<string>();
                fields.AddRange(CreateFields);
                fields.AddRange(ModifyFields);
                _userIgnoreFields = fields.ToArray();
                return _userIgnoreFields;
            }
        }
        private static string[] _createFields { get; set; }
        private static string[] CreateFields
        {
            get
            {
                if (_createFields != null) return _createFields;
                _createFields = AppSetting.CreateMember.GetType().GetProperties()
                    .Select(x => x.GetValue(AppSetting.CreateMember)?.ToString())
                    .Where(w => !string.IsNullOrEmpty(w)).ToArray();
                return _createFields;
            }
        }

        private static string[] _modifyFields { get; set; }
        private static string[] ModifyFields
        {
            get
            {
                if (_modifyFields != null) return _modifyFields;
                _modifyFields = AppSetting.ModifyMember.GetType().GetProperties()
                    .Select(x => x.GetValue(AppSetting.ModifyMember)?.ToString())
                    .Where(w => !string.IsNullOrEmpty(w)).ToArray();
                return _modifyFields;
            }
        }

        /// <summary>
        /// ??????
        /// 1???????????????????????????????????????????????????????????????
        /// 2?????????????????????????????????????????????????????????
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public virtual WebResponseContent Update(SaveModel saveModel)
        {
            if (UpdateOnExecute != null)
            {
                Response = UpdateOnExecute(saveModel);
                if (CheckResponseResult()) return Response;
            }
            if (saveModel == null)
                return Response.Error(ResponseType.ParametersLack);


            //if (WorkFlowManager.Exists<T>())
            //{
            //    var auditProperty = TProperties.Where(x => x.Name.ToLower() == "auditstatus").FirstOrDefault();
            //    string value = saveModel.MainData[auditProperty.Name]?.ToString();
            //    if (WorkFlowManager.GetAuditStatus<T>(value) != 1)
            //    {
            //        return Response.Error("???????????????????????????????????????");
            //    }
            //}
            Type type = typeof(T);

            //??????????????????,?????????????????????
            UserInfo userInfo = UserContext.Current.UserInfo;
            saveModel.SetDefaultVal(AppSetting.ModifyMember, userInfo);


            //????????????????????????????????????????????????
            string result = type.ValidateDicInEntity(saveModel.MainData, true, false, UserIgnoreFields);
            if (result != string.Empty)
                return Response.Error(result);

            PropertyInfo mainKeyProperty = type.GetKeyProperty();
            //????????????
            Type detailType = null;
            if (saveModel.DetailData != null || saveModel.DelKeys != null)
            {
                saveModel.DetailData = saveModel.DetailData == null
                    ? new List<Dictionary<string, object>>()
                    : saveModel.DetailData.Where(x => x.Count > 0).ToList();

                detailType = GetRealDetailType();

                result = detailType.ValidateDicInEntity(saveModel.DetailData, true, false, new string[] { mainKeyProperty.Name });
                if (result != string.Empty) return Response.Error(result);

                //????????????????????????,?????????????????????????????????????????????,????????????????????????????????????????????????,???????????????????????????(2020.04.25)
                //string foreignKey = type.GetTypeCustomValue<System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute>(x => new { x.Name });
                //if (!string.IsNullOrEmpty(foreignKey))
                //{
                //    var _mainKeyProperty = detailType.GetProperties().Where(x => x.Name.ToLower() == foreignKey.ToLower()).FirstOrDefault();
                //    if (_mainKeyProperty != null)
                //    {
                //        mainKeyProperty = _mainKeyProperty;
                //    }
                //}
            }

            //??????????????????????????????????????????????????????????????????,int long????????????0,guid :0000-000....
            object keyDefaultVal = mainKeyProperty.PropertyType.Assembly.CreateInstance(mainKeyProperty.PropertyType.FullName);//.ToString();
                                                                                                                               //????????????????????????
            if (mainKeyProperty == null
                || !saveModel.MainData.ContainsKey(mainKeyProperty.Name)
                || saveModel.MainData[mainKeyProperty.Name] == null
                )
            {
                return Response.Error(ResponseType.NoKey);
            }

            object mainKeyVal = saveModel.MainData[mainKeyProperty.Name];
            //??????????????????????????????
            (bool, string, object) validation = mainKeyProperty.ValidationValueForDbType(mainKeyVal).FirstOrDefault();
            if (!validation.Item1)
                return Response.Error(ResponseType.KeyError);

            object valueType = mainKeyVal.ToString().ChangeType(mainKeyProperty.PropertyType);
            //????????????????????????????????????????????????
            if (valueType == null ||
                (!valueType.GetType().Equals(mainKeyProperty.PropertyType)
                || valueType.ToString() == keyDefaultVal.ToString()
                ))
                return Response.Error(ResponseType.KeyError);

            if (saveModel.MainData.Count <= 1) return Response.Error("????????????????????????????????????????????????model!");

            // 2020.08.15???????????????????????????????????????
            if (IsMultiTenancy && !UserContext.Current.IsSuperAdmin)
            {
                CheckUpdateMultiTenancy(mainKeyProperty.PropertyType == typeof(Guid) ? "'" + mainKeyVal.ToString() + "'" : mainKeyVal.ToString(), mainKeyProperty.Name);
                if (CheckResponseResult())
                {
                    return Response;
                }
            }


            Expression<Func<T, bool>> expression = mainKeyProperty.Name.CreateExpression<T>(mainKeyVal.ToString(), LinqExpressionType.Equal);
            if (!repository.Exists(expression)) return Response.Error("????????????????????????!");
            //???????????????????????????????????????
            if (detailType == null)
            {
                saveModel.SetDefaultVal(AppSetting.ModifyMember, userInfo);
                T mainEntity = saveModel.MainData.DicToEntity<T>();
                if (UpdateOnExecuting != null)
                {
                    Response = UpdateOnExecuting(mainEntity, null, null, null);
                    if (CheckResponseResult()) return Response;
                }
                //?????????!CreateFields.Contains???????????????
                repository.Update(mainEntity, type.GetEditField().Where(c => saveModel.MainData.Keys.Contains(c) && !CreateFields.Contains(c)).ToArray());
                if (base.UpdateOnExecuted == null)
                {
                    repository.SaveChanges();
                    Response.OK(ResponseType.SaveSuccess);
                }
                else
                {
                    Response = repository.DbContextBeginTransaction(() =>
                    {
                        repository.SaveChanges();
                        Response = UpdateOnExecuted(mainEntity, null, null, null);
                        return Response;
                    });
                }
                if (Response.Status) Response.Data = new { data = mainEntity };
                if (Response.Status && string.IsNullOrEmpty(Response.Message))
                    Response.OK(ResponseType.SaveSuccess);
                return Response;
            }

            saveModel.DetailData = saveModel.DetailData.Where(x => x.Count > 0).ToList();

            //????????????
            PropertyInfo detailKeyInfo = detailType.GetKeyProperty();
            //????????????
            //  string detailKeyType = mainKeyProperty.GetTypeCustomValue<ColumnAttribute>(c => new { c.TypeName });
            //??????????????????????????????????????????

            string deatilDefaultVal = detailKeyInfo.PropertyType.Assembly.CreateInstance(detailKeyInfo.PropertyType.FullName).ToString();
            foreach (Dictionary<string, object> dic in saveModel.DetailData)
            {
                //???????????????????????????????????????????????????????????????????????????????????????
                if (!dic.ContainsKey(detailKeyInfo.Name))
                {
                    dic.Add(detailKeyInfo.Name, keyDefaultVal);
                    if (dic.ContainsKey(mainKeyProperty.Name))
                    {
                        dic[mainKeyProperty.Name] = keyDefaultVal;
                    }
                    else
                    {
                        dic.Add(mainKeyProperty.Name, keyDefaultVal);
                    }
                    continue;
                }
                if (dic[detailKeyInfo.Name] == null)
                    return Response.Error(ResponseType.NoKey);

                //?????????????????????
                string detailKeyVal = dic[detailKeyInfo.Name].ToString();
                if (!detailKeyInfo.ValidationValueForDbType(detailKeyVal).FirstOrDefault().Item1
                    || deatilDefaultVal == detailKeyVal)
                    return Response.Error(ResponseType.KeyError);

                //??????????????????????????????
                if (detailKeyVal != keyDefaultVal.ToString() && (!dic.ContainsKey(mainKeyProperty.Name) || dic[mainKeyProperty.Name] == null || dic[mainKeyProperty.Name].ToString() == keyDefaultVal.ToString()))
                {
                    return Response.Error(mainKeyProperty.Name + "????????????!");
                }
            }

            if (saveModel.DetailData.Exists(c => c.Count <= 2))
                return Response.Error("??????????????????????????????????????????????????????model!");
            return this.GetType().GetMethod("UpdateToEntity")
                .MakeGenericMethod(new Type[] { detailType })
                .Invoke(this, new object[] { saveModel, mainKeyProperty, detailKeyInfo, keyDefaultVal })
                as WebResponseContent;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="delList">????????????????????????(?????????????????????)</param>
        /// <returns></returns>
        public virtual WebResponseContent Del(object[] keys, bool delList = true)
        {
            Type entityType = typeof(T);
            var keyProperty = entityType.GetKeyProperty();
            if (keyProperty == null || keys == null || keys.Length == 0) return Response.Error(ResponseType.NoKeyDel);

            IEnumerable<(bool, string, object)> validation = keyProperty.ValidationValueForDbType(keys);
            if (validation.Any(x => !x.Item1))
            {
                return Response.Error(validation.Where(x => !x.Item1).Select(s => s.Item2 + "</br>").Serialize());
            }
            string tKey = keyProperty.Name;
            if (string.IsNullOrEmpty(tKey))
                return Response.Error("????????????????????????");

            if (DelOnExecuting != null)
            {
                Response = DelOnExecuting(keys);
                if (CheckResponseResult()) return Response;
            }

            FieldType fieldType = entityType.GetFieldType();
            string joinKeys = (fieldType == FieldType.Int || fieldType == FieldType.BigInt)
                 ? string.Join(",", keys)
                 : $"'{string.Join("','", keys)}'";

            // 2020.08.15???????????????????????????????????????
            if (IsMultiTenancy && !UserContext.Current.IsSuperAdmin)
            {
                CheckDelMultiTenancy(joinKeys, tKey);
                if (CheckResponseResult())
                {
                    return Response;
                }
            }

            string sql = $"DELETE FROM {entityType.GetEntityTableName() } where {tKey} in ({joinKeys});";
            // 2020.08.06??????pgsql????????????
            if (DBType.Name == DbCurrentType.PgSql.ToString())
            {
                sql = $"DELETE FROM \"public\".\"{entityType.GetEntityTableName() }\" where \"{tKey}\" in ({joinKeys});";
            }
            if (delList)
            {
                Type detailType = GetRealDetailType();
                if (detailType != null)
                {
                    if (DBType.Name == DbCurrentType.PgSql.ToString())
                    {
                        sql += $"DELETE FROM \"public\".\"{detailType.GetEntityTableName()}\" where \"{tKey}\" in ({joinKeys});";
                    }
                    else
                    {
                        sql += $"DELETE FROM {detailType.GetEntityTableName()} where {tKey} in ({joinKeys});";
                    }
                }

            }

            //repository.DapperContext.ExcuteNonQuery(sql, CommandType.Text, null, true);

            //???????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????
            //??????????????? repository.DbContextBeginTransaction(()=>{//do delete......and other});
            //????????????????????????DelOnExecuted?????????????????????
            Response = repository.DbContextBeginTransaction(() =>
            {
                repository.ExecuteSqlCommand(sql);
                if (DelOnExecuted != null)
                {
                    Response = DelOnExecuted(keys);
                }
                return Response;
            });
            if (Response.Status && string.IsNullOrEmpty(Response.Message)) Response.OK(ResponseType.DelSuccess);
            return Response;
        }

        private static string[] auditFields = new string[] { "auditid", "auditstatus", "auditor", "auditdate", "auditreason" };

        /// <summary>
        /// ????????????????????????????????????AuditId?????????ID ,AuditStatus????????????,Auditor?????????,Auditdate????????????,Auditreason????????????
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="auditStatus"></param>
        /// <param name="auditReason"></param>
        /// <returns></returns>
        public virtual WebResponseContent Audit(object[] keys, int? auditStatus, string auditReason)
        {
            if (keys == null || keys.Length == 0)
                return Response.Error("??????????????????!");

            Expression<Func<T, bool>> whereExpression = typeof(T).GetKeyName().CreateExpression<T>(keys[0], LinqExpressionType.Equal);
            T entity = repository.FindAsIQueryable(whereExpression).FirstOrDefault();

            //??????????????????
            if (WorkFlowManager.Exists<T>(entity))
            {
                var auditProperty = TProperties.Where(x => x.Name.ToLower() == "auditstatus").FirstOrDefault();
                if (auditProperty == null)
                {
                    return Response.Error("??????????????????????????????AuditStatus");
                }

                AuditStatus status = (AuditStatus)Enum.Parse(typeof(AuditStatus), auditStatus.ToString());
                if (auditProperty.GetValue(entity).GetInt() != (int)AuditStatus.?????????)
                {
                    return Response.Error("??????????????????????????????");
                }
                Response = repository.DbContextBeginTransaction(() =>
                {
                    return WorkFlowManager.Audit<T>(entity, status, auditReason, auditProperty, AuditWorkFlowExecuting, AuditWorkFlowExecuted);
                });
                if (Response.Status)
                {
                    return Response.OK(ResponseType.AuditSuccess);
                }
                return Response.Error(Response.Message??"????????????");
            }


            //????????????
            PropertyInfo property = TProperties.GetKeyProperty();
            if (property == null)
                return Response.Error("?????????????????????!");

            UserInfo userInfo = UserContext.Current.UserInfo;

            //???????????????????????????????????????????????????

            PropertyInfo[] updateFileds = TProperties.Where(x => auditFields.Contains(x.Name.ToLower())).ToArray();
            List<T> auditList = new List<T>();
            foreach (var value in keys)
            {
                object convertVal = value.ToString().ChangeType(property.PropertyType);
                if (convertVal == null) continue;

                entity = Activator.CreateInstance<T>();
                property.SetValue(entity, convertVal);
                foreach (var item in updateFileds)
                {
                    switch (item.Name.ToLower())
                    {
                        case "auditid":
                            item.SetValue(entity, userInfo.User_Id);
                            break;
                        case "auditstatus":
                            item.SetValue(entity, auditStatus);
                            break;
                        case "auditor":
                            item.SetValue(entity, userInfo.UserTrueName);
                            break;
                        case "auditdate":
                            item.SetValue(entity, DateTime.Now);
                            break;
                        case "auditreason":
                            item.SetValue(entity, auditReason);
                            break;
                    }
                }
                auditList.Add(entity);
            }
            if (base.AuditOnExecuting != null)
            {
                Response = AuditOnExecuting(auditList);
                if (CheckResponseResult()) return Response;
            }
            Response = repository.DbContextBeginTransaction(() =>
            {
                repository.UpdateRange(auditList, updateFileds.Select(x => x.Name).ToArray(), true);
                if (base.AuditOnExecuted != null)
                {
                    Response = AuditOnExecuted(auditList);
                    if (CheckResponseResult()) return Response;
                }
                return Response.OK();
            });
            if (Response.Status)
            {
                return Response.OK(ResponseType.AuditSuccess);
            }
            return Response.Error(Response.Message);
        }

        public virtual (string, T, bool) ApiValidate(string bizContent, Expression<Func<T, object>> expression = null)
        {
            return ApiValidateInput<T>(bizContent, expression);
        }

        /// <summary>
        /// ???????????????api?????????????????????
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="bizContent"></param>
        /// <param name="input"></param>
        /// <param name="expression">??????????????????</param>
        /// <returns>(string,TInput, bool) string:??????????????????,TInput???bizContent?????????????????????,bool:??????????????????</returns>
        public virtual (string, TInput, bool) ApiValidateInput<TInput>(string bizContent, Expression<Func<TInput, object>> expression)
        {
            return ApiValidateInput(bizContent, expression, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="bizContent"></param>
        /// <param name="expression">??????????????????????????????x=>new { x.UserName,x.Value }</param>
        /// <param name="validateExpression">??????????????????????????????????????????????????????????????????</param>
        /// <returns>(string,TInput, bool) string:??????????????????,TInput???bizContent?????????????????????,bool:??????????????????</returns>
        public virtual (string, TInput, bool) ApiValidateInput<TInput>(string bizContent, Expression<Func<TInput, object>> expression, Expression<Func<TInput, object>> validateExpression)
        {
            try
            {
                TInput input = JsonConvert.DeserializeObject<TInput>(bizContent);
                if (!(input is System.Collections.IList))
                {
                    Response = input.ValidationEntity(expression, validateExpression);
                    return (Response.Message, input, Response.Status);
                }
                System.Collections.IList list = input as System.Collections.IList;
                for (int i = 0; i < list.Count; i++)
                {
                    Response = list[i].ValidationEntity(expression?.GetExpressionProperty(),
                        validateExpression?.GetExpressionProperty());
                    if (CheckResponseResult())
                        return (Response.Message, default(TInput), false);
                }
                return ("", input, true);
            }
            catch (Exception ex)
            {
                Response.Status = false;
                Response.Message = ApiMessage.ParameterError;
                Logger.Error(LoggerType.HandleError, bizContent, null, ex.Message);
            }
            return (Response.Message, default(TInput), Response.Status);
        }

        /// <summary>
        /// ????????????????????????????????????,???????????????List<TSource>?????????List<TResult>???TSource?????????TResult
        /// ???????????????Dictionary???????????????
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="resultExpression">????????????????????????????????????</param>
        /// <param name="sourceExpression">???????????????????????????????????????</param>
        /// ????????????????????????????????????List?????????x => new { x[0].MenuName, x[0].Menu_Id}?????????????????????MenuName,Menu_Id??????
        ///  List<Sys_Menu> list = new List<Sys_Menu>();
        ///  list.MapToObject<List<Sys_Menu>, List<Sys_Menu>>(x => new { x[0].MenuName, x[0].Menu_Id}, null);
        ///  
        ///???????????????????????????????????????????????????x => new { x.MenuName, x.Menu_Id}?????????????????????MenuName,Menu_Id??????
        ///  Sys_Menu sysMenu = new Sys_Menu();
        ///  sysMenu.MapToObject<Sys_Menu, Sys_Menu>(x => new { x.MenuName, x.Menu_Id}, null);
        /// <returns></returns>
        public virtual TResult MapToEntity<TSource, TResult>(TSource source, Expression<Func<TResult, object>> resultExpression,
            Expression<Func<TSource, object>> sourceExpression = null) where TResult : class
        {
            return source.MapToObject<TSource, TResult>(resultExpression, sourceExpression);
        }

        /// <summary>
        /// ??????????????????????????????????????????,???????????????
        /// ???????????????a a1= new a();b b1= new b();  a1.P=b1.P; a1.Name=b1.Name;
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="result"></param>
        /// <param name="expression">??????????????????????????????,??????x=>new {x.Name,x.P},????????????????????????Name???P??????</param>
        public virtual void MapValueToEntity<TSource, TResult>(TSource source, TResult result, Expression<Func<TResult, object>> expression = null) where TResult : class
        {
            source.MapValueToEntity<TSource, TResult>(result, expression);
        }
        /// <summary>
        /// 2021.07.04??????code="-1"???????????????????????????????????????????????????->??????????????????????????????
        /// </summary>
        /// <returns></returns>
        private bool CheckResponseResult()
        {
            return !Response.Status || Response.Code == "-1";
        }
    }
}
