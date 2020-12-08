using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.DAL.Entities
{
	public abstract class BaseEntity<T>
	{
		public T Id { get; set; }
	}
}
