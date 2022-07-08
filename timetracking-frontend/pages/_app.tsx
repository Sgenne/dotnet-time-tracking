import "../styles/globals.css";
import { AppProps } from "next/app";
import { AuthContextProvider } from "../auth/AuthContext";
import SignInGuard from "../auth/SignInGuard";
import PageWithLayout from "../types/PageWithLayout";
import { ReactElement } from "react";

type AppPropsWithLayout = AppProps & {
  Component: PageWithLayout;
};

function App({ Component, pageProps }: AppPropsWithLayout) {
  const getLayout = Component.getLayout ?? ((page) => page);

  const content: ReactElement = getLayout(<Component {...pageProps} />);

  return (
    <AuthContextProvider>
      <SignInGuard>{content}</SignInGuard>
    </AuthContextProvider>
  );
}

export default App;
