import { ReactElement, useEffect, useState } from "react";
import { useAuthContext } from "../auth/AuthContext";
import Router from "next/router";

const WithAuthentication = <TProps,>(
  WrappedComponent: React.JSXElementConstructor<TProps>
) => {
  const RequiresAuthentication = (props: TProps) => {
    const { isSignedIn } = useAuthContext();

    useEffect(() => {
      if (!isSignedIn) Router.push("/login");
    }, [isSignedIn]);

    return isSignedIn ? <WrappedComponent {...props} /> : <div>loading...</div>;
  };
  return RequiresAuthentication;
};

export default WithAuthentication;
