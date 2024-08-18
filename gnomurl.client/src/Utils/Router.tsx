import * as React from "react";
import * as ReactDOM from "react-dom/client";
import {
    createBrowserRouter,
} from "react-router-dom";

import Home from "../Pages/Home";
import RedirectURLInfo from "../Pages/URLInfo";
import Info from "../Pages/Info";
import Layout from "../Components/Layout";

const Error = () => <div>Unexpected Error</div>

const router = createBrowserRouter([
    {
        path: "/",
        element: <Layout />,
        errorElement: <Error />,
        children: [
            {
                path: "/",
                element: <Home />,
                errorElement: <Error />
            },
            {
                path: "/view-url",
                element: <RedirectURLInfo />,
                errorElement: <Error />
            },
            {
                path: "/info",
                element: <Info />,
                errorElement: <Error />
            },
        ]
    }
]);

export default router;