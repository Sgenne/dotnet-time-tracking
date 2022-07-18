
import "../styles/globals.css";
import { AppProps } from "next/app";
import { AuthContextProvider } from "../auth/AuthContext";
import PageWithLayout from "../types/PageWithLayout";
import { ReactElement } from "react";
import { useDefaultLayout } from "../components/layouts/DefaultLayout";

type AppPropsWithLayout = AppProps & {
  Component: PageWithLayout;
};

function App({ Component, pageProps }: AppPropsWithLayout) {
  const getLayout = Component.getLayout ?? useDefaultLayout;

  const content: ReactElement = getLayout(<Component {...pageProps} />);

  return <AuthContextProvider>{content}</AuthContextProvider>;
}

export default App;
