﻿using System;

namespace Grocery.EFDataAccess.Entity
{
	public class BaseEntity
	{
		public Guid Id { get; set; }
		public DateTime CreateDate { get; set; }
	}
}
