import { createBrowserRouter, RouteObject } from "react-router";
import React, { Suspense, lazy } from "react";
import Loading from "components/utils/Loading";

const Authors = lazy(() => import("pages/Authors"));
const Categories = lazy(() => import("pages/Categories"));

const routes: RouteObject[] = [
	{
		path: "/",
		element: (
			<Suspense fallback={<Loading />}>
				<Authors />
			</Suspense>
		)
	},
	{
		path: "/categories",
		element: (
			<Suspense fallback={<Loading />}>
				<Categories />
			</Suspense>
		)
	}
];

const Router = createBrowserRouter(routes);

export default Router;
