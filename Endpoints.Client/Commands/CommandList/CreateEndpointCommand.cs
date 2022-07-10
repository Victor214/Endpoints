﻿using Endpoints.Client;
using Endpoints.Client.Commands.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Commands.CommandList
{
    public class CreateEndpointCommand : BaseCommand
    {
        public override string BaseText => "1) Insert a new endpoint";

        private CreateEndpointInput ReadInput()
        {
            Console.WriteLine("Enter a serial number (text):");
            string endpointSerialNumber = ReadString();

            Console.WriteLine("Enter a meter model id (text):");
            string meterModelId = ReadString();

            Console.WriteLine("Enter a meter number (integer):");
            int meterNumber = ReadInt();

            Console.WriteLine("Enter a meter firmware version (text):");
            string meterFirmwareVersion = ReadString();

            Console.WriteLine("Enter a meter switch state (integer):");
            Console.WriteLine("  0) Disconnected");
            Console.WriteLine("  1) Connected");
            Console.WriteLine("  2) Armed");
            int switchState = ReadInt();

            CreateEndpointInput input = new CreateEndpointInput
            {
                EndpointSerialNumber = endpointSerialNumber,
                MeterModelId = meterModelId,
                MeterNumber = meterNumber,
                MeterFirmwareVersion = meterFirmwareVersion,
                SwitchState = switchState
            };
            return input;
        }

        public override async Task ExecuteAsync()
        {
            var createEndpointInput = ReadInput();
            var createEndpointResponse = await Client.PostAsJsonAsync($"{ClientConfig.ApiPath}/api/Endpoint/", createEndpointInput);
            if (!createEndpointResponse.IsSuccessStatusCode)
            {
                await DisplayError(createEndpointResponse);
                return;
            }
            Console.WriteLine("Endpoint created successfully.");
        }
    }
}
