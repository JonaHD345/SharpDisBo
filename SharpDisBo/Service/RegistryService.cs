using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDisBo.Service
{
  /// <summary>
  /// This class provides methods for setting and retrieving values in the Windows registry.
  /// </summary>
  public class RegistryService
  {
    /// <summary>
    /// Sets a value in the Windows registry.
    /// </summary>
    /// <param name="subKey">The subkey in which the value should be set.</param>
    /// <param name="valueName">The name of the value to be set.</param>
    /// <param name="value">The value to be set.</param>
    public void SetValue(string subKey, string valueName, string value)
    {
      // Create or open the specified subkey in the current user context
      RegistryKey key = Registry.CurrentUser.CreateSubKey(subKey);

      if (key != null)
      {
        // Set the value in the subkey
        key.SetValue(valueName, value);
        // Close the key
        key.Close();
      }
    }

    /// <summary>
    /// Retrieves a value from the Windows registry.
    /// </summary>
    /// <param name="subKey">The subkey from which the value should be retrieved.</param>
    /// <param name="valueName">The name of the value to be retrieved.</param>
    /// <returns>The retrieved value as a string, or null if the value was not found.</returns>
    public string GetValue(string subKey, string valueName)
    {
      // Open the specified subkey in the current user context
      RegistryKey key = Registry.CurrentUser.OpenSubKey(subKey);

      if (key != null)
      {
        // Retrieve the value from the subkey
        object value = key.GetValue(valueName);

        // Close the key
        key.Close();
        if (value != null)
        {
          // Return the value as a string
          return value.ToString();
        }
      }
      return null;
    }
  }
}
