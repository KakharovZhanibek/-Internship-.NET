using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Documentation
{
    public class Specifier<T> : ISpecifier
    {
        public string GetApiDescription()
        {
            ApiDescriptionAttribute apiDescriptionAttribute = typeof(T).GetCustomAttributes().FirstOrDefault() as ApiDescriptionAttribute;
            if (apiDescriptionAttribute != null)
                return apiDescriptionAttribute.Description;
            else
                return null;
        }

        public string[] GetApiMethodNames()
        {
            MethodInfo[] methods = typeof(T).GetMethods();
            List<string> methodNames = new List<string>();
            foreach (MethodInfo methodInfo in methods)
            {
                var attrs = methodInfo.GetCustomAttributes();
                foreach (Attribute attr in attrs)
                {
                    ApiMethodAttribute apiMethodAttribute = attr as ApiMethodAttribute;
                    if (apiMethodAttribute != null)
                        methodNames.Add(methodInfo.Name);
                }
            }
            return methodNames.ToArray();
        }

        public string GetApiMethodDescription(string methodName)
        {
            if (typeof(T)
                .GetMethods()
                .Any(a => a.Name == methodName)
                &&
                typeof(T)
                    .GetMethods()
                    .FirstOrDefault(a => a.Name == methodName)
                    .GetCustomAttributes().Any(a => a.GetType() == typeof(ApiDescriptionAttribute)))
            {
                ApiDescriptionAttribute apiDescriptionAttribute = typeof(T)
                    .GetMethods()
                    .FirstOrDefault(a => a.Name == methodName)
                    .GetCustomAttributes()
                    .FirstOrDefault(f => f.GetType() == typeof(ApiDescriptionAttribute)) as ApiDescriptionAttribute;
                return apiDescriptionAttribute.Description;
            }
            else
                return null;
        }

        public string[] GetApiMethodParamNames(string methodName)
        {
            bool IsMethodExists = typeof(T).GetMethods().Any(a => a.Name == methodName);

            if (IsMethodExists)
            {
                return typeof(T).GetMethod(methodName).GetParameters().Select(s => s.Name).ToArray();
            }
            else
                return null;
        }

        public string GetApiMethodParamDescription(string methodName, string paramName)
        {
            bool IsMethodExists = typeof(T).GetMethods().Any(a => a.Name == methodName);

            if (IsMethodExists)
            {
                MethodInfo methodInfo = typeof(T).GetMethod(methodName);

                bool IsMethodParamExists = methodInfo.GetParameters().Any(a => a.Name == paramName);

                if (IsMethodParamExists)
                {
                    ParameterInfo parameterInfo = methodInfo.GetParameters().FirstOrDefault(f => f.Name == paramName);

                    bool IsParamHaveDesciption = parameterInfo.GetCustomAttributes().Any(a => a.GetType() == typeof(ApiDescriptionAttribute));

                    if (IsParamHaveDesciption)
                    {
                        ApiDescriptionAttribute apiDescriptionAttribute = parameterInfo
                                                                                    .GetCustomAttributes()
                                                                                    .FirstOrDefault(a => a.GetType() == typeof(ApiDescriptionAttribute)) as ApiDescriptionAttribute;
                        return apiDescriptionAttribute.Description;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public ApiParamDescription GetApiMethodParamFullDescription(string methodName, string paramName)
        {
            bool IsMethodExists = typeof(T).GetMethods().Any(a => a.Name == methodName);

            CommonDescription commonDescription = new CommonDescription();
            commonDescription.Name = paramName;

            ApiParamDescription apiParamDescription = new ApiParamDescription();
            apiParamDescription.ParamDescription = commonDescription;

            if (IsMethodExists)
            {
                MethodInfo methodInfo = typeof(T).GetMethod(methodName);

                bool IsMethodParamExists = methodInfo.GetParameters().Any(a => a.Name == paramName);

                if (IsMethodParamExists)
                {
                    ParameterInfo parameterInfo = methodInfo.GetParameters().FirstOrDefault(f => f.Name == paramName);

                    bool IsParamHaveDescription = parameterInfo.GetCustomAttributes().Any();

                    if (IsParamHaveDescription)
                    {
                        IEnumerable<Attribute> attrs = parameterInfo.GetCustomAttributes();

                        foreach (Attribute attribute in attrs)
                        {
                            if (attribute.GetType() == typeof(ApiDescriptionAttribute))
                            {
                                commonDescription.Description = (attribute as ApiDescriptionAttribute).Description;
                            }
                            if (attribute.GetType() == typeof(ApiRequiredAttribute))
                            {
                                apiParamDescription.Required = (attribute as ApiRequiredAttribute).Required;
                            }
                            if (attribute.GetType() == typeof(ApiIntValidationAttribute))
                            {
                                apiParamDescription.MinValue = (attribute as ApiIntValidationAttribute).MinValue;
                                apiParamDescription.MaxValue = (attribute as ApiIntValidationAttribute).MaxValue;
                            }

                        }

                        return apiParamDescription;
                    }
                    else
                        return apiParamDescription;
                }
                else
                    return apiParamDescription;
            }
            else
                return apiParamDescription;
        }

        public ApiMethodDescription GetApiMethodFullDescription(string methodName)
        {
            CommonDescription commonDescription = new CommonDescription();
            commonDescription.Name = methodName;
            ApiMethodDescription apiMethodDescription = new ApiMethodDescription();
            apiMethodDescription.MethodDescription = commonDescription;

            bool IsMethodExists = typeof(T).GetMethods().Any(a => a.Name == methodName);

            if (IsMethodExists)
            {
                MethodInfo methodInfo = typeof(T).GetMethod(methodName);
                bool IsMethodHasApiMethodAttribute = methodInfo.GetCustomAttributes().Any(a => a.GetType() == typeof(ApiMethodAttribute));

                if (IsMethodHasApiMethodAttribute)
                {

                    if (methodInfo.GetCustomAttributes().Any(a => a.GetType() == typeof(ApiDescriptionAttribute)))
                    {
                        ApiDescriptionAttribute methodDescription = methodInfo
                                                                    .GetCustomAttributes()
                                                                    .FirstOrDefault(a => a.GetType() == typeof(ApiDescriptionAttribute)) as ApiDescriptionAttribute;

                        apiMethodDescription.MethodDescription.Description = methodDescription.Description;
                    }
                }
                else
                    return null;
                bool IsMethodHasParams = methodInfo.GetParameters().Any();

                if (IsMethodHasParams)
                {
                    IEnumerable<ParameterInfo> parametersInfo = methodInfo.GetParameters().AsEnumerable();
                    List<ApiParamDescription> paramDescriptions = new List<ApiParamDescription>();

                    foreach (ParameterInfo parameterInfo in parametersInfo)
                    {
                        CommonDescription paramsCommonDescription = new CommonDescription();
                        paramsCommonDescription.Name = parameterInfo.Name;
                        ApiParamDescription apiParamDescription = new ApiParamDescription();
                        apiParamDescription.ParamDescription = paramsCommonDescription;

                        bool IsParamHasAttributes = parameterInfo.GetCustomAttributes().Any();
                        if (IsParamHasAttributes)
                        {
                            IEnumerable<Attribute> paramsAttributes = parameterInfo.GetCustomAttributes();
                            foreach (Attribute attribute in paramsAttributes)
                            {
                                if (attribute.GetType() == typeof(ApiDescriptionAttribute))
                                {
                                    paramsCommonDescription.Description = (attribute as ApiDescriptionAttribute).Description;
                                }
                                if (attribute.GetType() == typeof(ApiRequiredAttribute))
                                {
                                    apiParamDescription.Required = (attribute as ApiRequiredAttribute).Required;
                                }
                                if (attribute.GetType() == typeof(ApiIntValidationAttribute))
                                {
                                    apiParamDescription.MinValue = (attribute as ApiIntValidationAttribute).MinValue;
                                    apiParamDescription.MaxValue = (attribute as ApiIntValidationAttribute).MaxValue;
                                }
                            }
                            paramDescriptions.Add(apiParamDescription);
                        }
                        else
                            return apiMethodDescription;
                    }
                    apiMethodDescription.ParamDescriptions = paramDescriptions.ToArray();
                }
                else
                    return apiMethodDescription;

                ApiParamDescription returnParamDescription = new ApiParamDescription();
                bool IsReturnParamHasAttributes = methodInfo.ReturnParameter.GetCustomAttributes().Any();

                if (IsReturnParamHasAttributes)
                {
                    IEnumerable<Attribute> returnParamAttributes = methodInfo.ReturnParameter.GetCustomAttributes();

                    foreach (Attribute attribute in returnParamAttributes)
                    {
                        if (attribute.GetType() == typeof(ApiDescriptionAttribute))
                        {
                            commonDescription.Description = (attribute as ApiDescriptionAttribute).Description;
                        }
                        if (attribute.GetType() == typeof(ApiRequiredAttribute))
                        {
                            returnParamDescription.Required = (attribute as ApiRequiredAttribute).Required;
                        }
                        if (attribute.GetType() == typeof(ApiIntValidationAttribute))
                        {
                            returnParamDescription.MinValue = (attribute as ApiIntValidationAttribute).MinValue;
                            returnParamDescription.MaxValue = (attribute as ApiIntValidationAttribute).MaxValue;
                        }
                    }
                    apiMethodDescription.ReturnDescription = returnParamDescription;

                    return apiMethodDescription;
                }
                else
                    return apiMethodDescription;
            }
            else
                return apiMethodDescription;
        }
    }
}