import React, { ChangeEventHandler } from "react";
import TextInputProps from "../../../types/InputProps";
import { getInputChangeHandler } from "../../../utils/adapters/InputElementChangeAdapter";
import TextInput from "./TextInput";
import styles from "../../../styles/utils/input/HiddenTextInput.module.css";

const HiddenTextInput = (props: TextInputProps) => (
  <TextInput {...props} styles={styles} />
);

export default HiddenTextInput;
