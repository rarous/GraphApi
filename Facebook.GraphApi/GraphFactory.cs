using System;

namespace Facebook.GraphApi {

  public class GraphFactory {

    readonly IAuthentication authentication;

    public GraphFactory(IAuthentication authentication) {
      this.authentication = authentication;
    }

    public Graph Create() {
      var accessToken = authentication.GetAccessToken();
      return new Graph(accessToken);
    }
  }
}
