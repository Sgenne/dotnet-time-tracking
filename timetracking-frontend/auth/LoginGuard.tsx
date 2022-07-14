import { useRouter } from "next/router";
import { ReactElement, useEffect, useState } from "react";
import { useAuthContext } from "./AuthContext";

const LoginGuard = ({ children }: { children: ReactElement }) => {
  const authContext = useAuthContext();
  const router = useRouter();

  const url = router.pathname;

  useEffect(() => {
    if (!authContext.isSignedIn && url !== "/login") {
      router.push("/login");
    }
  }, [authContext.isSignedIn, router, url]);

  useEffect(() => {}, []);

  return children;
};

interface RedirectState {
  hasRedirected: boolean;
  redirectedFrom: string;
}

const defaultReducerState: RedirectState = {
  hasRedirected: false,
  redirectedFrom: "",
};

interface RedirectAction {
  type: string;
  payload: { redirectedFrom?: string };
}

const redirectReducer = (
  state: RedirectState,
  action: RedirectAction
): RedirectState => {
  const type = action.type;
  const payload = action.payload;

  if (type === "REDIRECT_TO_LOGIN" && payload.redirectedFrom) {
    return {
      ...state,
      hasRedirected: true,
      redirectedFrom: payload.redirectedFrom,
    };
  }

  if (type === "REDIRECT_FROM_LOGIN") {
    return defaultReducerState;
  }

  return state;
};

export default LoginGuard;
