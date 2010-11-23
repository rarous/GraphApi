namespace Facebook.GraphApi {

  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Net;
  using System.Text;

  /// <summary>
  /// Extensions for <see cref="HttpWebRequest"/>.
  /// </summary>
  public static class RequestExtensions {

    const string FormUrlEncoded = "application/x-www-form-urlencoded";

    /// <summary>
    /// Post data from dictionary via request. Only if request method id POST.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static HttpWebRequest PostData(this HttpWebRequest request, IDictionary<string, object> data) {

      if (request.Method != WebRequestMethods.Http.Post) {
        return request;
      }

      byte[] postData = GetPostData(data);

      return request.PostData(postData);
    }

    static byte[] GetPostData(IDictionary<string, object> data) {
      string postData = data.ToQueryString();
      return Encoding.ASCII.GetBytes(postData);
    }

    static HttpWebRequest PostData(this HttpWebRequest request, byte[] postData) {

      request.
        PreparePostRequest(postData).
        GetRequestStreamAsObservable().
        Run(WriteToStream(postData));

      return request;
    }

    static HttpWebRequest PreparePostRequest(this HttpWebRequest request, byte[] postData) {

      request.ContentLength = postData.Length;
      request.ContentType = FormUrlEncoded;

      return request;
    }

    static IObservable<Stream> GetRequestStreamAsObservable(this HttpWebRequest request) {
      var getRequestStreamAsObservable = request.ObserveRequestStream();
      return getRequestStreamAsObservable();
    }

    static Func<IObservable<Stream>> ObserveRequestStream(this HttpWebRequest request) {

      Func<AsyncCallback, object, IAsyncResult> begin = request.BeginGetRequestStream;
      Func<IAsyncResult, Stream> end = request.EndGetRequestStream;

      return Observable.FromAsyncPattern<Stream>(begin, end);
    }

    static Action<Stream> WriteToStream(byte[] postDataBytes) {
      return requestStream => {
        using (requestStream) {
          requestStream.Write(postDataBytes, 0, postDataBytes.Length);
        }
      };
    }

    /// <summary>
    /// Reads requests response text even if request is bad (error response).
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static string ReadResponse(this HttpWebRequest request) {
      using (var response = GetResponse(request))
      using (var reader = new StreamReader(response.GetResponseStream())) {
        return reader.ReadToEnd();
      }
    }

    static WebResponse GetResponse(HttpWebRequest request) {
      try {
        return request.GetWebResponseAsObservable().First();
      }
      catch (WebException ex) {
        return ex.Response;
      }
    }

    static IObservable<WebResponse> GetWebResponseAsObservable(this HttpWebRequest request) {
      var getWebResponseAsObservable = ObserveAsyncRequest(request);
      return getWebResponseAsObservable();
    }

    static Func<IObservable<WebResponse>> ObserveAsyncRequest(HttpWebRequest request) {

      Func<AsyncCallback, object, IAsyncResult> begin = request.BeginGetResponse;
      Func<IAsyncResult, WebResponse> end = request.EndGetResponse;

      return Observable.FromAsyncPattern<WebResponse>(begin, end);
    }
  }
}