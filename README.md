# Hue.Sharp
This is an API for communicating with your Philips Hue lamps via C#.

## Usage

First you have to create a new Hue object:
```
var hue = new Hue("USER_TOKEN", "IP_ADRESS");
```

Now we can get information about all the lights connected to your brigde:
```
var response = await hue.GetInfoOfAllLightsAsync();
```

When we have all the information about the lights we can control them e.g. like this:
```
var firstLight = hue.Lights.First();
await firstLight.TurnOnAsync();
await firstLight.SetColor(Color.Fuchsia);
```

You can also change specific and multiple properties at once like this:
```
await firstLight.ChangeParametersAsync(new LightParameters { Brightness = 42, ColorTemperature = 499 });
```
