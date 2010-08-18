using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using Rhino.Mocks;

namespace Facebook.GraphApi.Tests {

  public static class MockHelpers {

    public static HttpContextBase FakeHttpContext(this MockRepository mocks) {
      HttpContextBase context = mocks.PartialMock<HttpContextBase>();
      HttpRequestBase request = mocks.PartialMock<HttpRequestBase>();
      HttpResponseBase response = mocks.PartialMock<HttpResponseBase>();
      HttpSessionStateBase session = mocks.PartialMock<HttpSessionStateBase>();
      HttpServerUtilityBase server = mocks.PartialMock<HttpServerUtilityBase>();

      SetupResult.For(context.Request).Return(request);
      SetupResult.For(context.Response).Return(response);
      SetupResult.For(context.Session).Return(session);
      SetupResult.For(context.Server).Return(server);

      mocks.Replay(context);
      return context;
    }

    public static HttpContextBase FakeHttpContext(this MockRepository mocks, string url) {
      HttpContextBase context = FakeHttpContext(mocks);
      context.Request.SetupRequestUrl(url);
      return context;
    }

    public static void SetHttpMethodResult(this HttpRequestBase request, string httpMethod) {
      SetupResult.
        For(request.HttpMethod).
        Return(httpMethod);
    }

    public static void SetupRequestUrl(this HttpRequestBase request, string url) {
      if (url == null) {
        throw new ArgumentNullException("url");
      }

      if (url.StartsWith("~/") == false) {
        throw new ArgumentException("Sorry, we expect a virtual url starting with \"~/\".");
      }

      SetupResult.
        For(request.QueryString).
        Return(GetQueryStringParameters(url));
      SetupResult.
        For(request.AppRelativeCurrentExecutionFilePath).
        Return(GetUrlFileName(url));
      SetupResult.
        For(request.PathInfo).
        Return(String.Empty);
    }

    private static NameValueCollection GetQueryStringParameters(string url) {

      if (url.Contains("?") == false) {
        return null;
      }

      return HttpUtility.ParseQueryString(url.Split('?').Last());
    }

    private static string GetUrlFileName(string url) {
      if (url.Contains("?"))
        return url.Split('?').First();
      else
        return url;
    }
  }
}
