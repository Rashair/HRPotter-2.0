using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPotter.Helpers
{
    // TODO: Delete
    public static class ViewsFactory
    {
        public static ViewResult OkView(ViewResult view)
        {
            view.StatusCode = StatusCodes.Status200OK;
            return view;
        }

        public static PartialViewResult OkView(PartialViewResult view)
        {
            view.StatusCode = StatusCodes.Status200OK;
            return view;
        }
    }
}
