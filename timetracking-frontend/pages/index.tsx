import type { NextPage } from "next";
import withAuthentication from "../higherOrderComponents/WithAuthentication";
import styles from "../styles/Home.module.css";

const Home: NextPage = () => {
  return (
    <div className={styles.container}>
      <h1>Index</h1>
    </div>
  );
};

export default withAuthentication(Home);
