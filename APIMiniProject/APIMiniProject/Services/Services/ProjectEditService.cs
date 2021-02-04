﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APIMiniProject
{
	public class ProjectEditService
	{
		public ProjectEditCallManager ProjectEditCallManager { get; set; }
		public int Status { get; set; }
		public ProjectEditService(ProjectEditCallManager projectEditCallManager)
		{
			ProjectEditCallManager = projectEditCallManager;
		}

		public void EditProject(int id, string name, int color = -1)
		{
			JObject jsonbody = new JObject(new JProperty("name", name));
			if (color > -1)
			{
				jsonbody.Add("color", color);
			}
			Status = (int)ProjectEditCallManager.PostProject(id, jsonbody).StatusCode;
		}
	}
}
