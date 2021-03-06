﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SqlSugarRepository
{
    /// <summary>
    /// 复杂查询对象
    /// </summary>
    public interface  ISqlable
    {
        /// <summary>
        /// 存储sqlable对象
        /// </summary>
         object SqlableCore { get; set; }

        /// <summary>
        /// Form
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="shortName">表名简写</param>
        /// <returns></returns>
        ISqlable From(string tableName, string shortName);

        /// <summary>
        /// Form
        /// </summary>
        /// <param name="shortName">表名简写</param>
        /// <returns></returns>
        ISqlable From<T>(string shortName);


        /// <summary>
        /// Join
        /// </summary>
        /// <param name="tableName">表名字符串</param>
        /// <param name="shortName">表名简写</param>
        /// <param name="leftFiled">join左边连接字段</param>
        /// <param name="rightFiled">join右边连接字段</param>
        /// <param name="type">join类型</param>
        /// <returns></returns>
        ISqlable Join(string tableName, string shortName, string leftFiled, string rightFiled, JoinType type);

        /// <summary>
        /// Join
        /// </summary>
        /// <param name="shortName">表名简写</param>
        /// <param name="leftFiled">join左边连接字段</param>
        /// <param name="rightFiled">join右边连接字段</param>
        /// <param name="type">join类型</param>
        /// <returns></returns>
        ISqlable Join<T>(string shortName, string leftFiled, string rightFiled, JoinType type);


        /// <summary>
        /// Where
        /// </summary>
        /// <param name="where">查询条件、开头无需写 AND或者WHERE</param>
        /// <returns></returns>
        ISqlable Where(string where);

        /// <summary>
        /// OrderBy
        /// </summary>
        /// <param name="orderBy">排序字段，可以多个</param>
        /// <returns></returns>
        ISqlable OrderBy(string orderBy);

        /// <summary>
        /// Apply
        /// </summary>
        /// <param name="applySql">apply主体内容</param>
        /// <param name="shotName">apply简写</param>
        /// <param name="type">Apply类型</param>
        /// <returns></returns>
        ISqlable Apply(string applySql, string shotName, ApplyType type);

        /// <summary>
        /// GroupBy
        /// </summary>
        /// <param name="groupBy">GroupBy字段，可以多个</param>
        /// <returns></returns>
        ISqlable GroupBy(string groupBy);

        /// <summary>
        /// 设置查询列执行查询，并且将结果集转成List《T》
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileds">查询列</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <param name="preSql">在这语句之前可插入自定义SQL</param>
        /// <param name="nextSql">在这语句之后可以插自定义SQL</param>
        /// <returns></returns>
        List<T> SelectToList<T>(string fileds, object whereObj = null, string preSql = null, string nextSql = null) where T : class;



        /// <summary>
        /// 设置查询列执行查询，并且将结果集转成DataTable
        /// </summary>
        /// <param name="fileds">查询列</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <returns></returns>
        DataTable SelectToDataTable(string fileds, object whereObj = null);


        /// <summary>
        /// 设置查询列执行查询，并且将结果集转成json
        /// </summary>
        /// <param name="fileds">查询列</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <returns></returns>
        string SelectToJson(string fileds, object whereObj = null);

        /// <summary>
        /// 设置查询列执行查询，并且将结果集转成dynamic
        /// </summary>
        /// <param name="fileds">查询列</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <returns></returns>
       dynamic SelectToDynamic(string fileds, object whereObj = null);

        /// <summary>
        /// 生成查询结果对应的实体类字符串
        /// </summary>
        /// <param name="fileds">查询列</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <returns></returns>
        string ToClass(string fileds, object whereObj = null);


        /// <summary>
        /// 反回记录数
        /// </summary>
        /// <param name="whereObj">匿名参数 (例如：new{id=1,name="张三"})</param>
        /// <param name="preSql">在这语句之前可插入自定义SQL</param>
        /// <param name="nextSql">在这语句之后可以插自定义SQL</param>
        /// <returns></returns>
        int Count(object whereObj = null, string preSql = null, string nextSql = null);

        /// <summary>
        /// 设置查询列和分页参数执行查询，并且将结果集转成List《T》
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileds">查询列</param>
        /// <param name="orderByFiled">Order By字段，可以多个</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <returns></returns>
        List<T> SelectToPageList<T>(string fileds, string orderByFiled, int pageIndex, int pageSize, object whereObj = null) where T : class;

        /// <summary>
        /// 设置查询列和分页参数执行查询，并且将结果集转成DataTable
        /// </summary>
        /// <param name="fileds">查询列</param>
        /// <param name="orderByFiled">Order By字段，可以多个</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <returns></returns>
        DataTable SelectToPageTable(string fileds, string orderByFiled, int pageIndex, int pageSize, object whereObj = null);


        /// <summary>
        /// 设置查询列和分页参数执行查询，并且将结果集转成json
        /// </summary>
        /// <param name="fileds">查询列</param>
        /// <param name="orderByFiled">Order By字段，可以多个</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <returns></returns>
        string SelectToPageJson(string fileds, string orderByFiled, int pageIndex, int pageSize, object whereObj = null);

        /// <summary>
        /// 设置查询列和分页参数执行查询，并且将结果集转成dynamic
        /// </summary>
        /// <param name="fileds">查询列</param>
        /// <param name="orderByFiled">Order By字段，可以多个</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="whereObj">SQL参数,例如:new{id=1,name="张三"}</param>
        /// <returns></returns>
        dynamic SelectToPageDynamic(string fileds, string orderByFiled, int pageIndex, int pageSize, object whereObj = null);
    }
}
