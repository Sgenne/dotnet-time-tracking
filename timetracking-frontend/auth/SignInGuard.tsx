import { useRouter } from "next/router";
import { ReactElement, ReactNode, useEffect } from "react";
import { useAuthContext } from "./AuthContext";

const SignInGuard = ({ children }: { children: ReactElement }) => {
  const authContext = useAuthContext();
  const router = useRouter();

  const url = router.pathname;

  useEffect(() => {
    if (!authContext.isSignedIn && url !== "/login") {
      router.push("/login");
    }
  }, [authContext.isSignedIn, router, url]);

  return children;
};

export default SignInGuard;
