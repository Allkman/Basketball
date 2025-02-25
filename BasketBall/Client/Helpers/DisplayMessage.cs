﻿using BasketBall.Client.Helpers.Interfaces;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketBall.Client.Helpers
{
    //examples in: sweetalert2.github.io 
    public class DisplayMessage : IDisplayMessage
    {
        private readonly IJSRuntime _js;

        public DisplayMessage(IJSRuntime js)
        {
            _js = js;
        }

        public async ValueTask DisplayErrorMessage(string message)
        {
            await DoDisplayMessage("Error", message, "error");
        }

        public async ValueTask DisplaySuccessMessage(string message)
        {
            await DoDisplayMessage("Success", message, "success");
        }

        private async ValueTask DoDisplayMessage(string title, string message, string messageType)
        {
            await _js.InvokeVoidAsync("Swal.fire", title, message, messageType);
        }
    }
}
