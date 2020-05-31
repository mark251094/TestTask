using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TestTask.Common.Models
{
    public class ErrorDetails
    {
        public ErrorDetails()
        {

        }

        public ErrorDetails(ModelStateDictionary modelState)
            : this()
        {
            if (modelState == null)
            {
                throw new ArgumentNullException(nameof(modelState));
            }

            foreach (var keyModelStatePair in modelState)
            {
                var key = keyModelStatePair.Key;
                var errors = keyModelStatePair.Value.Errors;
                if (errors != null && errors.Count > 0)
                {
                    if (errors.Count == 1)
                    {
                        var errorMessage = GetErrorMessage(errors[0]);
                        Errors.Add(key, new[] { errorMessage });
                    }
                    else
                    {
                        var errorMessages = new string[errors.Count];
                        for (var i = 0; i < errors.Count; i++)
                        {
                            errorMessages[i] = GetErrorMessage(errors[i]);
                        }

                        Errors.Add(key, errorMessages);
                    }
                }
            }

            string GetErrorMessage(ModelError error)
            {
                return string.IsNullOrEmpty(error.ErrorMessage) ? "Unknown error" : error.ErrorMessage;
            }
        }

        [JsonProperty(PropertyName = "errors")]
        public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>(StringComparer.Ordinal);
    }
}

