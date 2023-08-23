﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Tests.AutoMock
{
    [CollectionDefinition(nameof(ClienteAutoMockerCollection))]    
    public class ClienteAutoMockerCollection :  ICollectionFixture<ClienteTestsAutomockFixture>
    {
    }
}
