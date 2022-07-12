import {
  createContext,
  ReactElement,
  ReactNode,
  useContext,
  useState,
} from "react";
import User from "../domain/User";

export interface AuthContextState {
  /**
   * Indicates if a User object and access token of a signed in user is stored in the context state.
   */
  isSignedIn: boolean;

  /**
   * Returns the User object of the signed in user, if one exists. If the function is called when
   * no user has been signed in, then an Error is thrown.
   */
  getSignedInUser: () => User;

  /**
   * Returns the access token of the currently signed in user. If no user is currently signed in, then
   * an Error is thrown.
   */
  getAccessToken: () => string;

  /**
   * Updates the stored state in response to a sign in.
   * @param accessToken The access token received when signing in.
   * @param signedInUser The User object of the successfully signed in user.
   */
  onSignIn: (accessToken: string, user: User) => void;

  /**
   * Updates the stored state in response to a sign out.
   * Removes the User object and access token from the context state.
   */
  onSignOut: () => void;
}

interface AuthContextProps {
  children: ReactElement;
}

const defaultAuthContextState: AuthContextState = {
  isSignedIn: false,
  getSignedInUser: () => {
    throw new Error();
  },
  getAccessToken: () => {
    throw new Error();
  },
  onSignIn: () => undefined,
  onSignOut: () => undefined,
};

const context = createContext<AuthContextState>(defaultAuthContextState);

export const AuthContextProvider = ({ children }: AuthContextProps) => {
  const [isSignedIn, setIsSignedIn] = useState(false);
  const [signedInUser, setSignedInUser] = useState<User>();
  const [accessToken, setAccessToken] = useState<string>();

  const getSignedInUser = (): User => {
    if (!(isSignedIn && signedInUser)) {
      throw NotSignedInError();
    }
    return signedInUser;
  };

  const getAccessToken = (): string => {
    if (!(isSignedIn && accessToken)) {
      throw NotSignedInError();
    }
    return accessToken;
  };

  const onSignIn = (accessToken: string, signedInUser: User) => {
    setIsSignedIn(true);
    setAccessToken(accessToken);
    setSignedInUser(signedInUser);
  };

  const onSignOut = () => {
    setIsSignedIn(false);
    setAccessToken(undefined);
    setSignedInUser(undefined);
  };

  console.log("isSignedIn: " + isSignedIn);
  console.log(
    "username: " +
      (signedInUser ? signedInUser.username : "No user is signed in.")
  );
  console.log("accessToken: " + accessToken);

  const state: AuthContextState = {
    isSignedIn,
    getSignedInUser,
    getAccessToken,
    onSignIn,
    onSignOut,
  };

  return <context.Provider value={state}>{children}</context.Provider>;
};

export const useAuthContext = () => useContext(context);

const NotSignedInError = () => new Error("No user is currently signed in.");
