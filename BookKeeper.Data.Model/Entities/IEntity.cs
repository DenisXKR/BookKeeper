﻿using System;

namespace BookKeeper.Data.Model.Entities
{
	public interface IEntity<TId>
	where TId : struct, IEquatable<TId>
	{
		TId Id { get; set; }
	}
}
