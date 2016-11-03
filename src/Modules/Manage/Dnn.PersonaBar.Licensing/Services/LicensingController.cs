﻿#region Copyright
// DotNetNuke® - http://www.dotnetnuke.com
// Copyright (c) 2002-2016
// by DotNetNuke Corporation
// All Rights Reserved
#endregion

using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dnn.PersonaBar.Library;
using Dnn.PersonaBar.Library.Attributes;
using DotNetNuke.Application;
using DotNetNuke.Instrumentation;

namespace Dnn.PersonaBar.Licensing.Services
{
    [ServiceScope(Scope = ServiceScope.Host)]
    public class LicensingController : PersonaBarApiController
    {
        private static readonly ILog Logger = LoggerSource.Instance.GetLogger(typeof(LicensingController));

        /// GET: api/Licensing/GetProduct
        /// <summary>
        /// Gets product info
        /// </summary>
        /// <param></param>
        /// <returns>product info</returns>
        [HttpGet]
        public HttpResponseMessage GetProduct()
        {
            try
            {
                var response = new
                {
                    Success = true,
                    Results = new
                    {
                        DotNetNukeContext.Current.Application.Name,
                        DotNetNukeContext.Current.Application.SKU,
                        DotNetNukeContext.Current.Application.Description
                    }
                };

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception exc)
            {
                Logger.Error(exc);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }
    }
}