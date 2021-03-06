﻿using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WatchdogBrowser.CustomEventArgs;

namespace WatchdogBrowser.Handlers {
    public class WatchdogLifespanHandler : ILifeSpanHandler {

        public event EventHandler<TabRequestEventArgs> NewTabRequest;
        public event EventHandler CloseTabRequest;

        public bool DoClose(IWebBrowser browserControl, IBrowser browser) {
            //CloseTabRequest?.Invoke(this, EventArgs.Empty);
            return false;
        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser) {
        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser) {

            Thread thread = new Thread(() => { CloseTabRequest?.Invoke(browser, EventArgs.Empty); });
            thread.Start();
        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser) {
            //return true;
            //return parent.OnBeforePopup(browserControl, browser, frame, targetUrl, targetFrameName, targetDisposition, userGesture, popupFeatures, windowInfo, browserSettings, ref noJavascriptAccess, out newBrowser);
            newBrowser = null;
            NewTabRequest?.Invoke(this, new TabRequestEventArgs { URL = targetUrl });
            return true;
        }
    }
}
