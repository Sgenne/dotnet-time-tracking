import type { NextPage } from "next";
import Router from "next/router";
import { useEffect } from "react";
import withAuthentication from "../higherOrderComponents/WithAuthentication";

const Home: NextPage = () => {

  useEffect(() => {
    Router.push("/timer");
  }, []);

  return (
    <div>
      <h1>Index</h1>
    </div>
  );
};

export default withAuthentication(Home);
