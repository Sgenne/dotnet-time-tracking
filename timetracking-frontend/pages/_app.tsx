
import "../styles/globals.css";
import { AppProps } from "next/app";
import { AuthContextProvider } from "../context/AuthContext";
import PageWithLayout from "../types/PageWithLayout";
import NextNProgress from "nextjs-progressbar";

type AppPropsWithLayout = AppProps & {
  Component: PageWithLayout;
};

function App({ Component, pageProps }: AppPropsWithLayout) {
  return <>
    <NextNProgress />
    <AuthContextProvider>
      <Component {...pageProps} />
    </AuthContextProvider>
  </>;
}

export default App;
