using System;

namespace Facebook.GraphApi {
  public interface IAuthentication {
    string GetAccessToken();
    bool IsAuthenticated();
  }
}
