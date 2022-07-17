import { ReactElement, useEffect, useState } from "react";
import { useAuthContext } from "../auth/AuthContext";
import Router from "next/router";
import LoadingSpinner from "../components/utils/loading/LoadingSpinner";

const withAuthentication = <TProps,>(
  WrappedComponent: React.JSXElementConstructor<TProps>
) => {
  const RequiresAuthentication = (props: TProps): ReactElement => {
    const { isSignedIn } = useAuthContext();

    useEffect(() => {
      if (!isSignedIn) Router.push("/login");
    }, [isSignedIn]);

    return isSignedIn ? <WrappedComponent {...props} /> : <LoadingSpinner />;
  };
  return RequiresAuthentication;
};

export default withAuthentication;
