using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;

namespace Facebook.GraphApi {

  public static class RequestExtensions {

    const string FormUrlEncoded = "application/x-www-form-urlencoded";
    
    public static void PostData(this HttpWebRequest request, IDictionary<string, object> data) {

      string postData = data.ToQueryString();
      byte[] postDataBytes = HttpUtility.UrlEncodeToBytes(postData);

      request.ContentType = FormUrlEncoded;
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

    private static WebResponse GetResponse(HttpWebRequest request) {
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