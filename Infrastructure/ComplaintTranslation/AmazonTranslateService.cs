using Amazon.Comprehend;
using Amazon.Comprehend.Model;
using Amazon.Runtime;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;
using Amazon.Translate;
using Amazon.Translate.Model;

namespace Infrastructure.ComplaintTranslation
{
    public class AmazonTranslateService
    {
        private readonly IAmazonTranslate _translateClient;
        private readonly IAmazonComprehend _comprehendClient;

        public AmazonTranslateService(
            IAmazonTranslate translateClient,
            IAmazonComprehend comprehendClient
        )
        {
            _translateClient = translateClient;
            _comprehendClient = comprehendClient;
        }

        public async Task<string> TranslateText(string sourceText, string targetLanguageCode)
        {
            var credentials = await GetTemporaryCredentials();

            var translateClient = new AmazonTranslateClient(
                credentials,
                Amazon.RegionEndpoint.USEast1
            );

            var request = new TranslateTextRequest
            {
                Text = sourceText,
                SourceLanguageCode = "auto", // Automatic language detection
                TargetLanguageCode = targetLanguageCode
            };

            var response = await translateClient.TranslateTextAsync(request);
            return response.TranslatedText;
        }

        public async Task<string> DetectLanguage(string text)
        {
            var credentials = await GetTemporaryCredentials();

            var comprehendClient = new AmazonComprehendClient(
                credentials,
                Amazon.RegionEndpoint.USEast1
            );

            var request = new DetectDominantLanguageRequest { Text = text };

            var response = await comprehendClient.DetectDominantLanguageAsync(request);
            return response.Languages.FirstOrDefault()?.LanguageCode;
        }

        private async Task<AWSCredentials> GetTemporaryCredentials()
        {
            // Replace with your IAM user's access key and secret access key
            var accessKey = "AKIAZK2IBPHNK6IGOHZX";
            var secretKey = "bmwFGg2C6bNSGVMcEMpX7xCxLwfDBfEXOA5mFrhu";

            // Instantiate an AmazonSecurityTokenServiceClient
            var stsClient = new AmazonSecurityTokenServiceClient(accessKey, secretKey);

            // Create a GetSessionTokenRequest to request temporary security credentials
            var sessionTokenRequest = new GetSessionTokenRequest
            {
                DurationSeconds = 3600 // Set the desired duration of the temporary credentials
            };

            // Send the GetSessionTokenRequest to STS and retrieve the temporary security credentials
            var sessionTokenResponse = await stsClient.GetSessionTokenAsync(sessionTokenRequest);

            // Extract the temporary security credentials from the response
            var credentials = sessionTokenResponse.Credentials;

            return new SessionAWSCredentials(
                credentials.AccessKeyId,
                credentials.SecretAccessKey,
                credentials.SessionToken
            );
        }
    }
}
