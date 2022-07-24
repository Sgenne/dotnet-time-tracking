import { ReactElement, useEffect } from "react";
import { useAuthContext } from "../auth/AuthContext";
import Router from "next/router";
import LoadingPage from "../components/utils/loading/LoadingPage";

const withAuthentication = <TProps,>(
  WrappedComponent: React.JSXElementConstructor<TProps>
) => {
  const RequiresAuthentication = (props: TProps): ReactElement => {
    const { isSignedIn } = useAuthContext();

    useEffect(() => {
      if (!isSignedIn) Router.push("/login");
    }, [isSignedIn]);

    return isSignedIn ? <WrappedComponent {...props} /> : <LoadingPage />;
  };
  return RequiresAuthentication;
};

export default withAuthentication;
