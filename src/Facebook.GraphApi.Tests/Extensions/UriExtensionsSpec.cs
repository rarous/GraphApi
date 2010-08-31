using System;
using System.Collections.Generic;
using Xunit;

namespace Facebook.GraphApi.Tests.Extensions {

  public class UriExtensionsSpec {

    [Fact]
    public void It_should_convert_string_to_URI() {

      var uri = "http://example.com".ToUri();

      Assert.NotNull(uri);
    }

    [Fact]
    public void It_should_create_URI_with_GET_paramaters() {

      var args = new Dictionary<string, object> { { "param", "value" } };
      var uri = "http://example.com".ToUri(args);

      Assert.Equal("?param=value", uri.Query);
    }

    [Fact]
    public void It_should_create_HttpRequest_from_URI_and_HTTP_verb() {

      var uri = new Uri("http://example.com");

      var request = uri.CreateWebRequest(HttpVerb.Post);

      Assert.NotNull(request);
      Assert.Equal("POST", request.Method);
    }
  }
}
