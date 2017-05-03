using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITsoft.PlatSystem.Models
{
    public class AjaxResponse
    {
        public AjaxResponse()
        {
            this.ShowMessage = true;
            this.RedirectUrl = string.Empty;
            this.State = ResultType.success.ToString();
        }
        public string State { get; set; }
        public string RedirectUrl { get; set; }

        public string Message { get; set; }

        public bool ShowMessage { get; set; }

        public bool Succeeded { get; set; }

        public string ErrorMessage { get; set; }
    }
}

public enum ResultType
{
    /// <summary>
    /// 消息结果类型
    /// </summary>
    info,
    /// <summary>
    /// 成功结果类型
    /// </summary>
    success,
    /// <summary>
    /// 警告结果类型
    /// </summary>
    warning,
    /// <summary>
    /// 异常结果类型
    /// </summary>
    error
}