// Copyright 2004-2011 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Castle.ActiveRecord.Framework.Internal
{
	using System;
	using System.Reflection;

	/// <summary>
	/// Model to represent a HasMany ( one to many ) association
	/// </summary>
	[Serializable]
	public class HasManyModel : IVisitable
	{
		private readonly PropertyInfo propInfo;
		private readonly HasManyAttribute hasManyAtt;
        private readonly ActiveRecordModel containingTypeModel;
		private DependentObjectModel dependentObjectModel;

		/// <summary>
		/// Initializes a new instance of the <see cref="HasManyModel"/> class.
		/// </summary>
		/// <param name="propInfo">The prop info.</param>
		/// <param name="hasManyAtt">The has many att.</param>
        /// <param name="containingTypeModel">The model for the type that contains the HasMany reference.</param>
		public HasManyModel(PropertyInfo propInfo, HasManyAttribute hasManyAtt, ActiveRecordModel containingTypeModel)
		{
			this.hasManyAtt = hasManyAtt;
			this.propInfo = propInfo;
            this.containingTypeModel = containingTypeModel;
		}

		/// <summary>
		/// Gets the property.
		/// </summary>
		/// <value>The property.</value>
		public PropertyInfo Property
		{
			get { return propInfo; }
		}

		/// <summary>
		/// Gets the has many attribute
		/// </summary>
		/// <value>The has many att.</value>
		public HasManyAttribute HasManyAtt
		{
			get { return hasManyAtt; }
		}

        /// <summary>
        /// This is a reference to the model (the ActiveRecord type) that defined the HasMany relationship.
        /// </summary>
        public ActiveRecordModel ContainingTypeModel
        {
            get { return containingTypeModel; }
        }

		/// <summary>
		/// Gets/Sets the the dependent object model
		/// </summary>
		/// <value>The dependent object model.</value>
		public DependentObjectModel DependentObjectModel
		{
			get { return dependentObjectModel; }
			set { dependentObjectModel = value; }
		}

		#region IVisitable Members

		/// <summary>
		/// Accepts the specified visitor and call the relevant IVisitor.Visit***() method
		/// </summary>
		/// <param name="visitor">The visitor.</param>
		public void Accept(IVisitor visitor)
		{
			visitor.VisitHasMany(this);
		}

		#endregion
	}
}
