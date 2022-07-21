import React, { ReactElement } from "react";
import styles from "../../styles/layouts/DefaultLayout.module.css";
import VerticalNavbar from "./navbar/VerticalNavbar";

export interface DefaultLayoutProps {
  children: ReactElement;
}

const DefaultLayout = ({ children }: DefaultLayoutProps) => {
  return <div className={styles["page-container"]}>
    <div className={styles["navbar-container"]}>
      <VerticalNavbar />
    </div>
    <div className={styles["content-container"]}>
      {children}
    </div>
  </div>;
};

export default DefaultLayout;

export const useDefaultLayout = (page: ReactElement) => (
  <DefaultLayout>{page}</DefaultLayout>
);
