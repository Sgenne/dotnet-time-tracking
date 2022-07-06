import "../styles/globals.css";
import { AppProps } from "next/app";
import { AuthContextProvider } from "../auth/AuthContext";
import SignInGuard from "../auth/SignInGuard";

function App({ Component, pageProps }: AppProps) {
  return (
    <AuthContextProvider>
      <SignInGuard>
        <Component {...pageProps} />
      </SignInGuard>
    </AuthContextProvider>
  );
}

export default App;
