using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Mvc.Utils.Session
{
    public class SessionUnits
    {
        public readonly IHttpContextAccessor _httpContextAccessor;

        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public SessionUnits(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetSession(string key, string value)
        {
            _session.SetString(key, value);
        }

        public string GetSession(string key)
        {
            return _session.GetString(key);
        }
    }
}
