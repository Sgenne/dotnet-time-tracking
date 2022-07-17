import "bootstrap/dist/css/bootstrap.css"

import "../styles/globals.css";
import { AppProps } from "next/app";
import { AuthContextProvider } from "../auth/AuthContext";
import PageWithLayout from "../types/PageWithLayout";
import { ReactElement } from "react";

type AppPropsWithLayout = AppProps & {
  Component: PageWithLayout;
};

function App({ Component, pageProps }: AppPropsWithLayout) {
  const getLayout = Component.getLayout ?? ((page) => page);

  const content: ReactElement = getLayout(<Component {...pageProps} />);

  return <AuthContextProvider>{content}</AuthContextProvider>;
}

export default App;
