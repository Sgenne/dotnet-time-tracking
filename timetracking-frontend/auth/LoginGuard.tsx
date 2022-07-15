import Router from "next/router";
import { ReactElement, useEffect, useReducer, useState } from "react";
import { AuthContextState, useAuthContext } from "./AuthContext";

const LoginGuard = ({ children }: { children: ReactElement }) => {
  const authContext: AuthContextState = useAuthContext();
  const [{ hasRedirected, redirectedFrom }, dispatch] = useReducer(
    redirectReducer,
    defaultReducerState
  );

  useEffect(() => {
    const url: string = Router.pathname;
    const shouldRedirect: boolean = !authContext.isSignedIn && url !== "/login";
    if (shouldRedirect) {
      Router.push("/login");
      dispatch(redirectToLoginAction(url));
    }
  }, [authContext.isSignedIn]);

  useEffect(() => {
    if (!authContext.isSignedIn) return;

    const newUrl: string = hasRedirected ? redirectedFrom : "/";

    Router.push(newUrl);
    dispatch(redirectFromLoginAction());
  }, [authContext.isSignedIn, hasRedirected, redirectedFrom]);

  return children;
};

const redirectToLoginAction = (redirectFromUrl: string): RedirectAction => ({
  type: RedirectActionType.REDIRECT_TO_LOGIN,
  payload: { redirectedFrom: redirectFromUrl },
});

const redirectFromLoginAction = (): RedirectAction => ({
  type: RedirectActionType.REDIRECT_FROM_LOGIN,
  payload: {},
});

interface RedirectState {
  hasRedirected: boolean;
  redirectedFrom: string;
}

const defaultReducerState: RedirectState = {
  hasRedirected: false,
  redirectedFrom: "",
};

enum RedirectActionType {
  REDIRECT_TO_LOGIN = "REDIRECT_TO_LOGIN",
  REDIRECT_FROM_LOGIN = "REDIRECT_FROM_LOGIN",
}

interface RedirectAction {
  type: RedirectActionType;
  payload: { redirectedFrom?: string };
}

const redirectReducer = (
  state: RedirectState,
  action: RedirectAction
): RedirectState => {
  const type = action.type;
  const payload = action.payload;

  if (type === RedirectActionType.REDIRECT_TO_LOGIN && payload.redirectedFrom) {
    return {
      ...state,
      hasRedirected: true,
      redirectedFrom: payload.redirectedFrom,
    };
  }

  if (type === RedirectActionType.REDIRECT_FROM_LOGIN) {
    return defaultReducerState;
  }

  return state;
};

export default LoginGuard;
