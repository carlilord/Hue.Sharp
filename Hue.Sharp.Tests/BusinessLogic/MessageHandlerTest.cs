using System.Linq;
using Hue.Sharp.BusinessLogic;
using Xunit;

namespace Hue.Sharp.Tests.BusinessLogic
{
    public class MessageHandlerTest
    {
		private string successState;
		private string failureState;
		private string unknownFailureState;
		private string lightState;
		private string allLightStates;
		
        public MessageHandlerTest()
        {
            successState = @"[
	            {
		            ""success"": {
			            ""/lights/1/state/on"": false
		            }
	            }
                ]";

			failureState = @"[
	                {
		                ""error"": {
			                ""type"": 3,
			                ""address"": ""/lights/1/stat"",
			                ""description"": ""resource, /lights/1/stat, not available""
		                }
	                }
                ]";

			unknownFailureState = @"[
	                {
		                ""error"": {
			                ""type"": 17,
			                ""address"": ""/lights/1/stat"",
			                ""description"": ""resource, /lights/1/stat, not available""
		                }
	                }
                ]";

			lightState = @"{
	            ""state"": {
		            ""on"": false,
		            ""bri"": 76,
		            ""hue"": 52349,
		            ""sat"": 21,
		            ""effect"": ""none"",
		            ""xy"": [
			            0.3743,
			            0.3557
		            ],
		            ""ct"": 239,
		            ""alert"": ""select"",
		            ""colormode"": ""xy"",
		            ""mode"": ""homeautomation"",
		            ""reachable"": true
	            },
	            ""swupdate"": {
		            ""state"": ""readytoinstall"",
		            ""lastinstall"": null
	            },
	            ""type"": ""Extended color light"",
	            ""name"": ""Hue color lamp 1"",
	            ""modelid"": ""LCT015"",
	            ""manufacturername"": ""Signify Netherlands B.V."",
	            ""productname"": ""Hue color lamp"",
	            ""capabilities"": {
		            ""certified"": true,
		            ""control"": {
			            ""mindimlevel"": 1000,
			            ""maxlumen"": 806,
			            ""colorgamuttype"": ""C"",
			            ""colorgamut"": [
				            [
					            0.6915,
					            0.3083
				            ],
				            [
					            0.17,
					            0.7
				            ],
				            [
					            0.1532,
					            0.0475
				            ]
			            ],
			            ""ct"": {
				            ""min"": 153,
				            ""max"": 500
			            }
		            },
		            ""streaming"": {
			            ""renderer"": true,
			            ""proxy"": true
		            }
	            },
	            ""config"": {
		            ""archetype"": ""sultanbulb"",
		            ""function"": ""mixed"",
		            ""direction"": ""omnidirectional""
	            },
	            ""uniqueid"": ""00:17:88:01:06:ed:ff:90-0b"",
	            ""swversion"": ""1.29.0_r21169"",
	            ""swconfigid"": ""75BEC85D"",
	            ""productid"": ""Philips-LCT015-2-A19ECLv5""
            }";

			allLightStates = @"{
	            ""1"": {
		            ""state"": {
				            ""on"": false,
			            ""bri"": 76,
			            ""hue"": 52349,
			            ""sat"": 21,
			            ""effect"": ""none"",
			            ""xy"": [
				            0.3743,
				            0.3557
			            ],
			            ""ct"": 239,
			            ""alert"": ""select"",
			            ""colormode"": ""xy"",
			            ""mode"": ""homeautomation"",
			            ""reachable"": true
		            },
		            ""swupdate"": {
			            ""state"": ""readytoinstall"",
			            ""lastinstall"": null
		            },
		            ""type"": ""Extended color light"",
		            ""name"": ""Hue color lamp 1"",
		            ""modelid"": ""LCT015"",
		            ""manufacturername"": ""Signify Netherlands B.V."",
		            ""productname"": ""Hue color lamp"",
		            ""capabilities"": {
			            ""certified"": true,
			            ""control"": {
				            ""mindimlevel"": 1000,
				            ""maxlumen"": 806,
				            ""colorgamuttype"": ""C"",
				            ""colorgamut"": [
					            [
						            0.6915,
						            0.3083
					            ],
					            [
						            0.17,
						            0.7
					            ],
					            [
						            0.1532,
						            0.0475
					            ]
				            ],
				            ""ct"": {
					            ""min"": 153,
					            ""max"": 500
				            }
			            },
			            ""streaming"": {
				            ""renderer"": true,
				            ""proxy"": true
			            }
		            },
		            ""config"": {
			            ""archetype"": ""sultanbulb"",
			            ""function"": ""mixed"",
			            ""direction"": ""omnidirectional""
		            },
		            ""uniqueid"": ""00:17:88:01:06:ed:ff:90-0b"",
		            ""swversion"": ""1.29.0_r21169"",
		            ""swconfigid"": ""75BEC85D"",
		            ""productid"": ""Philips-LCT015-2-A19ECLv5""
	            },
	            ""2"": {
		            ""state"": {
			            ""on"": false,
			            ""bri"": 58,
			            ""hue"": 41519,
			            ""sat"": 80,
			            ""effect"": ""none"",
			            ""xy"": [
				            0.3102,
				            0.3265
			            ],
			            ""ct"": 153,
			            ""alert"": ""select"",
			            ""colormode"": ""xy"",
			            ""mode"": ""homeautomation"",
			            ""reachable"": true
		            },
		            ""swupdate"": {
			            ""state"": ""readytoinstall"",
			            ""lastinstall"": ""2020-03-24T12:28:16""
		            },
		            ""type"": ""Extended color light"",
		            ""name"": ""Hue color lamp 2"",
		            ""modelid"": ""LCT015"",
		            ""manufacturername"": ""Signify Netherlands B.V."",
		            ""productname"": ""Hue color lamp"",
		            ""capabilities"": {
			            ""certified"": true,
			            ""control"": {
				            ""mindimlevel"": 1000,
				            ""maxlumen"": 806,
				            ""colorgamuttype"": ""C"",
				            ""colorgamut"": [
					            [
						            0.6915,
						            0.3083
					            ],
					            [
						            0.17,
						            0.7
					            ],
					            [
						            0.1532,
						            0.0475
					            ]
				            ],
				            ""ct"": {
					            ""min"": 153,
					            ""max"": 500
				            }
			            },
			            ""streaming"": {
				            ""renderer"": true,
				            ""proxy"": true
			            }
		            },
		            ""config"": {
			            ""archetype"": ""sultanbulb"",
			            ""function"": ""mixed"",
			            ""direction"": ""omnidirectional""
		            },
		            ""uniqueid"": ""00:17:88:01:04:37:63:d3-0b"",
		            ""swversion"": ""1.29.0_r21169"",
		            ""swconfigid"": ""75BEC85D"",
		            ""productid"": ""Philips-LCT015-2-A19ECLv5""
	            }
            }";
		}

        [Fact]
        public void When_Error_IsSuccessful_Is_False()
        {
			var handler = new MessageHandler();
			var response = handler.GetParsedResponse(failureState);
			Assert.False(response.IsSuccessful);
		}

		[Fact]
		public void When_Unknown_Error_Type()
		{
			var handler = new MessageHandler();
			var response = handler.GetParsedResponse(unknownFailureState);
			Assert.False(response.IsSuccessful);
			Assert.True(response.ErrorDetails.Type == Enums.ErrorType.Unknown);
		}

		[Fact]
		public void When_Success_IsSuccessful_Is_True()
		{
			var handler = new MessageHandler();
			var response = handler.GetParsedResponse(successState);
			Assert.True(response.IsSuccessful);
			Assert.Null(response.ErrorDetails);
		}

		[Fact]
		public void Can_Parse_One_Light_State()
		{
			var handler = new MessageHandler();
			var response = handler.GetParsedResponse(lightState);
			Assert.True(response.IsSuccessful);
			Assert.Null(response.ErrorDetails);
		}

		[Fact]
		public void Can_Parse_All_Light_State()
		{
			var handler = new MessageHandler();
			var response = handler.GetParsedResponse(allLightStates);
            Assert.True(response.Lights.First().State.Hue == 52349);
			Assert.True(response.IsSuccessful);
			Assert.Null(response.ErrorDetails);
		}
	}
}
