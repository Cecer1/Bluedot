﻿using Bluedot.HabboServer.Habbos;
using Bluedot.HabboServer.Network;

namespace Bluedot.HabboServer.ApiUsage.Plugins.DefaultRoomEventsFunctions
{
    internal static partial class PacketHandlers
    {
        internal static void ProcessEventCategoryValidationRequest(Habbo sender, IncomingMessage message)
        {
            ClassicIncomingMessage classicMessage = (ClassicIncomingMessage)message;
            int categoryID = classicMessage.PopWiredInt32();

            // TODO: Event manager

            new MEventCategoryValid
            {
                CategoryId = categoryID
            }.Send(sender);
        }
    }
}