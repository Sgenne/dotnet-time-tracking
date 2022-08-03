import Router from "next/router";
import { useEffect } from "react";
import { withDefaultLayout } from "../components/layouts/DefaultLayout";
import withAuthentication from "../higherOrderComponents/WithAuthentication";

const Home = () => {
  useEffect(() => {
    Router.push("/timer");
  }, []);

  return (
    <div>
      <h1>Index</h1>
    </div>
  );
};

export default withAuthentication(withDefaultLayout(Home));
