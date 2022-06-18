using Apinxt.Models;
using Jint;

namespace Apinxt.Handlers
{
    public class ApiAssertionHandler
    {
        private readonly Engine _jintEngine;        

        public ApiAssertionHandler(Engine jintEngine)
        {
            _jintEngine = jintEngine;            
        }

        public void SetResponseContext(Response response)
        {
            _jintEngine.SetValue("response", response);
        }

        public IEnumerable<ApiAssertionResult> RunAssertions(IList<ApiTest> tests)
        {

            var resultList = new List<ApiAssertionResult>();
            foreach (var test in tests) {

                try
                {
                    var result = _jintEngine
                       .Execute($"var {test.Name} = {test.Assertion}")
                       .GetValue(test.Name);

                    if (!result.IsBoolean())
                    {
                        resultList.Add(new ApiAssertionResult(test.Name, false, "The assertion expression doesn't return boolean", ""));
                        continue;
                    }

                    resultList.Add(new ApiAssertionResult(test.Name, result.AsBoolean(), "", ""));
                    
                }
                catch (Exception e)
                {   
                    resultList.Add(new ApiAssertionResult(test.Name, false, "Failed to evaluate", e.Message));
                }
            }

            return resultList;
        }
    }
}
