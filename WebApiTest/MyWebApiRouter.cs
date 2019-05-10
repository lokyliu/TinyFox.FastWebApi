﻿using Microsoft.Owin;
using TinyFox.FastWebApi;

namespace WebApiTest
{

    /// <summary>
    /// 路由器：自定义URL路由规则
    /// </summary>
    public class MyWebApiRouter : IWebApiRouter
    {
        /// <summary>
        /// 返回一个处理对象，如果当前请求不在处理之列则返回空
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public BaseWebApi RouteTo(IOwinContext c)
        {

            //用户请求的URL路径
            var path = c.Request.Path.Value;

            //将不同的请求路径交给不同的处理模块处理
            if (path == "/app1" || path.StartsWith("/app1/")) return new MyApp.MyApp1();
            if (path == "/app2" || path.StartsWith("/app2/")) return new MyApp.MyApp2();





            //根据其它特征处理
            // if(c.Request.Method=="POST") return  ......
            // if (c.Request.Host.Value=="www.google.com") return .....

            //返回空表示该请求不属于本webapi处理范围
            //将以404（找不到网页）的http状态码应答对方
            return null;

        }

    }
}
