using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Facebook.GraphApi {

  public static class RequestExtensions {

    const string FormUrlEncoded = "application/x-www-form-urlencoded";
    
    public static void PostData(this HttpWebRequest request, IDictionary<string, object> data) {

      byte[] postData = GetPostData(data);
      PreparePostRequest(request, postData);

      Observable.
        FromAsyncPattern<Stream>(request.BeginGetRequestStream, request.EndGetRequestStream)().
        Run(WriteToStream(postData));
    }

    static byte[] GetPostData(IDictionary<string, object> data) {
      string postData = data.ToQueryString();
      return Encoding.ASCII.GetBytes(postData);
    }

    static void PreparePostRequest(HttpWebRequest request, byte[] postData) {
      request.ContentLength = postData.Length;
      request.ContentType = FormUrlEncoded;
      request.Method = WebRequestMethods.Http.Post;
    }

    static Action<Stream> WriteToStream(byte[] postDataBytes) {
      return requestStream => {
        using (requestStream) {
          requestStream.Write(postDataBytes, 0, postDataBytes.Length);
        }
      };
    }

    public static string ReadResponse(this HttpWebRequest request) {

      using (var response = GetResponse(request)) 
      using (var reader = new StreamReader(response.GetResponseStream())) {
        return reader.ReadToEnd();
      }
    }

    static WebResponse GetResponse(HttpWebRequest request) {

      try {
        return Observable.
          FromAsyncPattern<WebResponse>(request.BeginGetResponse, request.EndGetResponse)().
          First();
      }
      catch (WebException ex) {
        return ex.Response;
      }
    }
  }
}