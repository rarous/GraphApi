using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Text;

namespace Facebook.GraphApi {

  public static class RequestExtensions {

    const string FormUrlEncoded = "application/x-www-form-urlencoded";
    const string UserAgent = "Facebook.GraphApi .net library (http://github.com/rarous/GraphApi)";
    
    public static void PostData(this HttpWebRequest request, IDictionary<string, object> data) {

      request.Method = WebRequestMethods.Http.Post;
      request.ContentType = FormUrlEncoded;
      request.UserAgent = UserAgent;

      string postData = data.ToQueryString();
      byte[] postDataBytes = Encoding.ASCII.GetBytes(postData);

      request.ContentLength = postDataBytes.Length;

      // TODO: async
      using (var requestStream = request.GetRequestStream()) {
        requestStream.Write(postDataBytes, 0, postDataBytes.Length);
      }
    }

    public static string ReadResponse(this HttpWebRequest request) {

      using (var response = GetResponse(request))
      using (var reader = new StreamReader(response.GetResponseStream())) {
        return reader.ReadToEnd();
      }
    }

    static WebResponse GetResponse(HttpWebRequest request) {
      try {
        // TODO: async
        return request.GetResponse();
      }
      catch (WebException ex) {
        return ex.Response;
      }
    }
  }
}