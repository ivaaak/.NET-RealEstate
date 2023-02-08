<<<<<<< Updated upstream:RealEstate.CQRS/BehaviorModels/RequestModels/Request.cs
﻿using System.Collections.ObjectModel;

namespace RealEstate.CQRS.BehaviorModels.RequestModels
=======
<<<<<<< Updated upstream:RealEstate.MediatR/BehaviorModels/RequestModels/Request.cs
﻿namespace RealEstate.MediatR.BehaviorModels.RequestModels
=======
﻿using System.Collections.ObjectModel;

namespace RealEstate.MediatR.BehaviorModels.RequestModels
>>>>>>> Stashed changes:RealEstate.CQRS/BehaviorModels/RequestModels/Request.cs
>>>>>>> Stashed changes:RealEstate.MediatR/BehaviorModels/RequestModels/Request.cs
{
    public class Request
    {
        //This is a placeholder and to be redone
        private readonly IList<string> data = new List<string>();

        public IEnumerable<string> Data { get; }
    }
}
