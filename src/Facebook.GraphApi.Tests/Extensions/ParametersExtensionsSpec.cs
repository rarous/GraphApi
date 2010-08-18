using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Facebook.GraphApi.Tests.Extensions {
  public class ParametersExtensionsSpec {

    [Fact]
    public void AddScope_should_return_same_distionary_when_permissions_are_none() {
      
      var args = new Dictionary<string, object>();

      var result = args.AddScope(Permissions.None);

      Assert.Equal(args, result);
    }

    public class When_AddScope_is_called_with_one_permission_selected {

      IDictionary<string, object> args;

      /// <summary>
      /// Initializes a new instance of the When_AddScope_is_called_with_one_permission_selected class.
      /// </summary>
      public When_AddScope_is_called_with_one_permission_selected() {

        args = new Dictionary<string, object>();

        args.AddScope(Permissions.Email);
      }

      [Fact]
      public void It_should_add_one_parameter() {

        Assert.Equal(1, args.Count);
      }

      [Fact]
      public void It_should_contain_lowercase_value() {

        Assert.Equal("email", args["scope"]);
      }
    }

    public class When_AddScope_is_called_with_more_permissions {

      IDictionary<string, object> args;

      public When_AddScope_is_called_with_more_permissions() {

        args = new Dictionary<string, object>();

        args.AddScope(Permissions.PublishStream | Permissions.Email);
      }

      [Fact]
      public void It_should_add_one_parameter() {

        Assert.Equal(1, args.Count);
      }

      [Fact]
      public void Values_should_be_comma_separated() {

        var values = args["scope"];

        Assert.Equal(2, values.ToString().Split(',').Length);
      }
    }

    public class When_ToUndescoreCasing_is_called_on_pascal_case_text {

      string result;

      public When_ToUndescoreCasing_is_called_on_pascal_case_text() {
        result = "PascalCase".ToUndescoreCasing();
      }

      [Fact]
      public void It_should_lowercase_letters() {
        
        Assert.True(result.Where(Char.IsLetter).All(Char.IsLower));
      }

      [Fact]
      public void It_should_separate_word_with_underscore() {

        Assert.True(result.Contains('_'));
      }

      [Fact]
      public void It_should_result_to_specific_text() {

        Assert.Equal("pascal_case", result);
      }
    }
  }
}
