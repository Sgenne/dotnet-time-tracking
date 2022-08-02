
import "../styles/globals.css";
import { AppProps } from "next/app";
import { AuthContextProvider } from "../context/AuthContext";
import PageWithLayout from "../types/PageWithLayout";
import { ReactElement } from "react";
import { useDefaultLayout } from "../components/layouts/DefaultLayout";
import Router from "next/router";

type AppPropsWithLayout = AppProps & {
  Component: PageWithLayout;
};

Router.events.on("routeChangeStart", () => console.log("routeChangeStart"))
Router.events.on("routeChangeComplete", () => console.log("routeChangeComplete"))
Router.events.on("routeChangeError", () => console.log("routeChangeError"))

function App({ Component, pageProps }: AppPropsWithLayout) {

  const getLayout = Component.getLayout ?? useDefaultLayout;

  const content: ReactElement = getLayout(<Component {...pageProps} />);

  return <AuthContextProvider>{content}</AuthContextProvider>;
}

export default App;
