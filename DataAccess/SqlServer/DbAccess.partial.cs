﻿using System;
using System.Data.SqlClient;

namespace DbParallel.DataAccess
{
	public partial class DbAccess
	{
		partial void OnSqlConnectionLost(Exception dbException, ref bool canRetry)
		{
			if (_Connection is SqlConnection)
			{
				SqlException e = dbException as SqlException;

				if (e == null)
					canRetry = false;
				else
					switch (e.Number)
					{
						case 233:
						case -2: canRetry = true; break;
						// To add other cases
						default: canRetry = false; break;
					}
			}
		}
	}
}

////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Copyright 2012 Abel Cheng
//	This source code is subject to terms and conditions of the Apache License, Version 2.0.
//	See http://www.apache.org/licenses/LICENSE-2.0.
//	All other rights reserved.
//	You must not remove this notice, or any other, from this software.
//
//	Original Author:	Abel Cheng <abelcys@gmail.com>
//	Created Date:		2013-07-‎29
//	Primary Host:		http://dbParallel.codeplex.com
//	Change Log:
//	Author				Date			Comment
//
//
//
//
//	(Keep clean code rather than complicated code plus long comments.)
//
////////////////////////////////////////////////////////////////////////////////////////////////////